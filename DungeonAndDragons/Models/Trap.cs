using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAndDragons.Models
{
    public class Trap
    {
        private int Damage;

        public Trap(int damage)
        {
            Damage = damage;
        }

        public void ActivateTrap()
        {
            Console.WriteLine("Armadilha ativada! Você sofreu " + Damage + " de dano.");
        }

        public int GetDamage()
        {
            return Damage;
        }
    }
}