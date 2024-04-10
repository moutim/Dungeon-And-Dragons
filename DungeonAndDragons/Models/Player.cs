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

        public Player(string name, int attack, string Vocation)
        {
            Name = name;
            Attack = attack;

            if (Vocation == "1")
            {
                Health = 100;
                Attack = 100;
            }
            else if (Vocation == "2")
            {
                Health = 50;
                Attack = 150;
            }
            else if (Vocation == "3")
            {
                Health = 150;
                Attack = 50;
            }
        }

        public void GetHealth()
        {
            Console.WriteLine($"Saúde do jogador: {Health}");
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