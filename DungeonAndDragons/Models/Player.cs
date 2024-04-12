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

        public Player(string name, string vocation)
        {
            Name = name;

            if (vocation == "1")
            {
                Health = 100;
                Attack = 30;
                Vocation = "Guerreiro";
            }
            else if (vocation == "2")
            {
                Health = 80;
                Attack = 40;
                Vocation = "Mago";
            }
            else if (vocation == "3")
            {
                Health = 60;
                Attack = 40;
                Vocation = "Arqueiro";
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