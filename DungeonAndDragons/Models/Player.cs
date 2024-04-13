using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAndDragons.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string Vocation { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public string Weapon { get; set; }
        public string? Key { get; set; }

        public Player(string name, string vocation)
        {
            Name = name;

            if (vocation == "1")
            {
                Health = 100;
                Attack = 30;
                Vocation = "Guerreiro";
                Weapon = "Machado";
                Key = null;
            }
            else if (vocation == "2")
            {
                Health = 80;
                Attack = 40;
                Vocation = "Mago";
                Weapon = "Cajado";
                Key = null;
            }
            else if (vocation == "3")
            {
                Health = 60;
                Attack = 40;
                Vocation = "Arqueiro";
                Weapon = "Arco";
                Key = null;
            }
        }

        public void GetHealth()
        {
            Console.WriteLine($"Saúde do {Vocation}: {Health}.");
        }

        public void ReduceHealth(int damage)
        {
            Health = Health - damage;
        }

        public void IncreaseHealth(int damage)
        {
            Health = Health + damage;
        }

        public void IsDeafeated()
        {
            Health = 0;
        }
    }
}