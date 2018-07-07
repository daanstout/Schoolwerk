using ResourceGatherer.Entities;
using ResourceGatherer.Entities.MovingEntities;
using ResourceGatherer.Materials;
using ResourceGatherer.Util;
using ResourceGatherer.World;
using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.States {
    public class GatherResourceState : IState {
        public void Enter(BaseEntity entity) {
            Console.WriteLine("Entity is now gathering resources.");
            Gatherer gatherer = entity as Gatherer;
            gatherer.path.Set(Path.GetPathTo(GameWorld.instance.tiles.tiles[TileSystem.GetIndexOfTile(gatherer.position)], Material.IDToMaterial(gatherer.matID)));
        }

        public void Execute(BaseEntity entity) {
            Gatherer gatherer = entity as Gatherer;
            if (gatherer.path.isFinished && !gatherer.noMatsLeft) {
                if (gatherer.CollectMaterialsFromTile(GameWorld.instance.tiles.tiles[TileSystem.GetIndexOfTile(gatherer.position)])) {
                    gatherer.path.Set(Path.GetPathTo(GameWorld.instance.tiles.tiles[TileSystem.GetIndexOfTile(gatherer.position)], Material.IDToMaterial(gatherer.matID)));
                } else {
                    gatherer.state.ChangeState(StoreResourcesState.instance);
                }
                if (gatherer.path.Count == 0) {
                    //if (!gatherer.noMatsLeft) {
                        gatherer.state.ChangeState(StoreResourcesState.instance);
                    //} else {
                        gatherer.noMatsLeft = true;
                        //GameWorld.instance.materialCollection += gatherer.inventory;
                        //gatherer.inventory.Clear();
                    //}
                }

                ResourceGatherer.instance.RedrawBackground();
            }
        }

        public void Exit(BaseEntity entity) {
            Console.WriteLine("Entity has now stopped gathering resources");
        }

        public static readonly GatherResourceState instance = new GatherResourceState();

        private GatherResourceState() { }
    }
}
