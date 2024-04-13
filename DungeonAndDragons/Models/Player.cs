using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAndDragons.Models
{
    public class Player
    {
        public static string Name { get; set; }
        public static string Vocation { get; set; }
        public static int Attack { get; set; }
        public static int Health { get; set; }
        public string Weapon { get; set; }
        public string? Key { get; set; }
        public static bool Potion { get; set; }

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

        public static void GetName()
        {
            Console.WriteLine($"Nome do jogador: {Name}");
        }

        public static void GetVocation()
        {
            Console.WriteLine($"Vocação do jogador: {Vocation}, Ataque: {Attack} e Vida: {Health}");
        }

        public static void GetHealth()
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

        public int GetAttack() 
        {
            return Attack;
        }
    }
}