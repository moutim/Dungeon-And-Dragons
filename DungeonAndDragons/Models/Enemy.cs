using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAndDragons.Models
{
    public class Enemy
    {
        private string Name { get; set; }
        private int Health { get; set; }
        private int Attack { get; set; }

        public Enemy(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;;
        }

        public void GetName()
        {
            Console.WriteLine(Name);
        }

        public void GetHealth()
        {
            Console.WriteLine($"Saúde do {Name}: {Health}");
        }

        public int EnemyAttack()
        {
            return Attack;
        }

        public void ReduceHealth(int damage)
        {
            Health = Health - damage;
        }

        public bool IsDefeated()
        {
            return Health <= 0;
        }
    }
}