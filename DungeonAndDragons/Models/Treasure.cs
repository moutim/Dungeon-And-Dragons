using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAndDragons.Models
{
    public class Treasure
    {
        private string Name;
        private bool IsCollected;

        public Treasure(string name)
        {
            Name = name;
            IsCollected = false;
        }

        public string getName()
        {
            return Name;
        }

        public bool isCollected()
        {
            return IsCollected;
        }

        public void collect()
        {
            IsCollected = true;
            Console.WriteLine("Você encontrou um tesouro: " + Name + "!");
        }
    }
}