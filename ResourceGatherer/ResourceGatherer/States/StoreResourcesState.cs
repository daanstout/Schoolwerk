using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceGatherer.Entities;
using ResourceGatherer.Entities.MovingEntities;
using ResourceGatherer.Util;
using ResourceGatherer.World;
using ResourceGatherer.World.Tiles;

namespace ResourceGatherer.States {
    public class StoreResourcesState : IState {
        public void Enter(BaseEntity entity) {
            Console.WriteLine("Entity is now storing resources");
            Gatherer gatherer = entity as Gatherer;
            gatherer.path.Set(Path.GetPathTo(GameWorld.instance.tiles.tiles[TileSystem.GetIndexOfTile(gatherer.position)], GameWorld.instance.tiles.tiles[GameWorld.instance.buildings[0].entrancePosition]));
        }

        public void Execute(BaseEntity entity) {
            Gatherer gatherer = entity as Gatherer;
            if(gatherer.position.Distance(gatherer.path.end) < 1) {
                GameWorld.instance.materialCollection += gatherer.inventory;
                gatherer.inventory.Clear();
                gatherer.state.ChangeState(GatherResourceState.instance);
            }
        }

        public void Exit(BaseEntity entity) {
            Console.WriteLine("Entity has now stopped storing resources");
        }

        public static readonly StoreResourcesState instance = new StoreResourcesState();

        private StoreResourcesState() { }
    }
}
