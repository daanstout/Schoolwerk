using ResourceGatherer.Materials;
using ResourceGatherer.States;
using ResourceGatherer.Util;
using ResourceGatherer.Util.SteeringBehaviours;
using ResourceGatherer.World;
using ResourceGatherer.World.Grids;
using ResourceGatherer.World.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// The remaining capacity of the gatherer
        /// </summary>
        public int remainingCapacity => carryCapacity - inventory.totalCount;

        /// <summary>
        /// The ID of the material this entity should chase after
        /// </summary>
        public int matID;

        /// <summary>
        /// A bool whether there are no more materials found
        /// </summary>
        public bool noMatsLeft = false;

        public int counter;

        //Lua script;

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
            entityType = Entity_Types.GATHERER;
            carryCapacity = carryCap;
            this.matID = matID;
            //script = new Lua();
            //script.LoadCLRPackage();
            //script.DoFile("./Scripts/Print.lua");
            inventory = new MaterialCollector();
            vehicle.addSteeringFactor = new Seek();
            state.SetState(GatherResourceState.instance);
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

            state.Update();
        }

        /// <summary>
        /// Draws the entity
        /// </summary>
        /// <param name="g">The graphics instance</param>
        public override void Render(Graphics g) {
            g.FillRectangle(new SolidBrush(Color.Red), new RectangleF(position - (scale / 2), scale));
            //Vector2D pos = GameWorld.instance.grid.GetGridPosition(position);
            Vector2D pos = GameWorld.instance.grid.GetGridPosition(currentGrid);

            g.DrawRectangle(new Pen(Color.Black), new Rectangle(pos, new Vector2D(Grid.GridWidth, Grid.GridHeight)));
            try {
                g.DrawLine(new Pen(Color.Black), position, position + heading * 15);
            } catch { }
        }

        /// <summary>
        /// Adds all the materials on the tile to the inventory
        /// </summary>
        /// <param name="tile">The tile to add from</param>
        /// <returns>False if the inventory is to large</returns>
        public bool CollectMaterialsFromTile(BaseTile tile) {
            while (tile.entityList.Count > 0) {
                MaterialStack stack = tile.entityList[0].GetStack();
                if (!AddMaterials(stack.material, stack.count)) {
                    int remaining = remainingCapacity;
                    AddMaterials(stack.material, remaining);
                    tile.entityList[0].Decrease(remaining);
                    return false;
                }
                tile.entityList.RemoveAt(0);
                if (remainingCapacity == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Adds materials to the inventory
        /// </summary>
        /// <param name="mat">The material to be added</param>
        /// <param name="count">The amount to add</param>
        /// <returns>False if the gatherer would go over their carry capacity</returns>
        public bool AddMaterials(Material mat, int count) {
            if (inventory.totalCount + count > carryCapacity)
                return false;
            else
                inventory.AddMaterial(mat, count);
            return true;
        }

        /// <summary>
        /// Adds materials to the inventory
        /// </summary>
        /// <param name="mat">The stack of materials to add</param>
        /// <returns>False if the gatherer would go over their carry capacity</returns>
        public bool AddMaterials(MaterialStack mat) {
            if (inventory.totalCount + mat.count > carryCapacity)
                return false;
            else
                inventory.AddMaterial(mat);
            return true;
        }

        /// <summary>
        /// Creates Debug Info
        /// </summary>
        /// <returns>A string with the important information</returns>
        public override string GetDebug() => string.Format("{0}\nMaximum Carry Capacity: {1}\nInventory: {2}", base.GetDebug(), carryCapacity, inventory);
    }
}
