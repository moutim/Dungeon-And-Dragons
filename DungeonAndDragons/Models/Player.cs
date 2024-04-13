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
                Health = 220;
                Attack = 20;
                Vocation = "Guerreiro";
                Weapon = "Machado";
                Key = null;
            }
            else if (vocation == "2")
            {
                Health = 150;
                Attack = 30;
                Vocation = "Mago";
                Weapon = "Cajado";
                Key = null;
            }
            else if (vocation == "3")
            {
                Health = 180;
                Attack = 25;
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
            Console.WriteLine($"Ataque: {Attack}");
            Console.WriteLine($"Vocação do jogador: {Vocation}");
        }

        public void GetWeapon()
        {
            Console.WriteLine($"Arma: {Weapon}");
        }

        public static void GetHealth()
        {
            Console.WriteLine($"Saúde do {Vocation}: {Health}");
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

        public void ChangeAttack(int attack) 
        {
            Attack = attack;
        }
    }
}