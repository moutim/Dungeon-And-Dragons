using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAndDragons.Models
{
    public class Treasure
    {
        private static string Name;
        private bool IsCollected;

        public Treasure(string name)
        {
            Name = name;
            IsCollected = false;
        }

        public static void GetName()
        {
            Console.WriteLine("Você encontrou um tesouro: " + Name + "!");
        }

        public bool isCollected()
        {
            return IsCollected;
        }

      
    }
}