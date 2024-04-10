using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAndDragons.Models
{
    public class Room
    {
        private string Name;

        private Dictionary<string, Room> Exits = new Dictionary<string, Room>();

        private Enemy Enemies;

        private Treasure Treasures;

        private Trap Traps;

        public Room(string name, Enemy enemy = null, Treasure treasure = null, Trap trap = null)
        {
            Name = name;
            Enemies = enemy;
            Treasures = treasure;
            Traps = trap;
        }

        public string GetName()
        {
            return Name;
        }

        public Dictionary<string, Room> GetExits()
        {
            return Exits;
        }

        public void AddExit(string direction, Room room)
        {
            Exits.Add(direction, room);
        }

        public Enemy GetEnemies()
        {
            return Enemies;
        }

        public Treasure GetTreasures()
        {
            return Treasures;
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies = enemy;
        }

        public void AddTreasure(Treasure treasure)
        {
            Treasures = treasure;
        }

        public bool HasTrap()
        {
            return Traps != null;
        }

        public Trap GetTrap()
        {
            return Traps;
        }

        public int ActivateTrap()
        {
            if (Traps != null)
            {
                int trapDamage = Traps.GetDamage();
                return trapDamage;
            }
            else
            {
                return 0;
            }
        }

        public void SetTrap(Trap trap)
        {
            Traps = trap;
        }
    }
}