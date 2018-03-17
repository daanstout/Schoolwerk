using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;
using ResourceGatherer.Entities.StaticEntities;
using ResourceGatherer.Materials;
using ResourceGatherer.Util;
using ResourceGatherer.World;
using ResourceGatherer.World.Grids;

namespace ResourceGatherer.Entities.MovingEntities {
    /// <summary>
    /// A temporary class, used to test things with
    /// </summary>
    public class Gatherer : MovingEntity {
        /// <summary>
        /// The max carry capacity of the entity
        /// </summary>
        public int carryCapacity;

        /// <summary>
        /// The inventory of the gatherer
        /// </summary>
        public MaterialCollector inventory;

        /// <summary>
        /// The ID of the material this entity should chase after
        /// </summary>
        protected int matID;

        /// <summary>
        /// A bool whether there are no more materials found
        /// </summary>
        protected bool noMatsLeft = false;

        public int counter;

        Lua script;

        /// <summary>
        /// The constructor of this class
        /// </summary>
        /// <param name="pos">The position of the entity</param>
        /// <param name="rad">The bounding radius of the entity</param>
        /// <param name="vel">The current velocity of the entity</param>
        /// <param name="maxSpd">The max speed of the entity</param>
        /// <param name="heading">The current heading of the entity</param>
        /// <param name="mass">The mass of the entity</param>
        /// <param name="scale">The scale of the entity</param>
        /// <param name="turnRate">The turn rate of the entity</param>
        /// <param name="maxForce">The max force the entity can endure</param>
        /// <param name="carryCap">The carry capacity of the entity</param>
        /// <param name="matID">THe id of the material this entity should chase after</param>
        public Gatherer(Vector2D pos, float rad, Vector2D vel, float maxSpd, Vector2D heading, float mass, Vector2D scale, float turnRate, float maxForce, int carryCap, int matID) : base(pos, rad, vel, maxSpd, heading, mass, scale, turnRate, maxForce) {
            carryCapacity = carryCap;
            this.matID = matID;
            script = new Lua();
            script.LoadCLRPackage();
            script.DoFile("./Scripts/Print.lua");
            inventory = new MaterialCollector();
        }

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="time_elapsed">The time since the last entity</param>
        public override void Update(float time_elapsed) {
            base.Update(time_elapsed);

            //LuaFunction f = script["incr"] as LuaFunction;
            //var returnData = f.Call(this);
            //Console.WriteLine(counter);

            if (path.isFinished && !noMatsLeft) {
                MaterialEntity entity = GameWorld.instance.tiles.tiles[GameWorld.instance.tiles.GetIndexOfTile(position)].entityList[0];
                //GameWorld.instance.materialCollection.AddMaterial(entity.material, 1);
                inventory.AddMaterial(entity.material, entity.quantity);
                GameWorld.instance.tiles.tiles[GameWorld.instance.tiles.GetIndexOfTile(position)].entityList.Clear();

                path.Set(Path.GetPathTo(GameWorld.instance.tiles.tiles[GameWorld.instance.tiles.GetIndexOfTile(position)], Material.IDToMaterial(matID)));

                if (path.Count == 0) {
                    noMatsLeft = true;
                    GameWorld.instance.materialCollection += inventory;
                }

                ResourceGatherer.instance.RedrawBackground();
            }
        }

        /// <summary>
        /// Draws the entity
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public override void Render(Graphics g) {
            g.FillRectangle(new SolidBrush(Color.Red), new RectangleF(position - (scale / 2), scale));
            Vector2D pos = GameWorld.instance.grid.GetGridPosition(position);
            //Console.WriteLine(pos);
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(pos, new Vector2D(Grid.GridWidth, Grid.GridHeight)));
            try {
                g.DrawLine(new Pen(Color.Black), position, position + heading * 15);
            } catch {

            }
        }
    }
}
