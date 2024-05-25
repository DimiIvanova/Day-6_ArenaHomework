using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    //- Has armor, which reduces the incoming damage between 20 and 60%.
    //- Every 5 hits can cause double damage.
    public class Knight : Hero
    {
        private int hitCount;

        public Knight() : this("Sir John") 
        {

        }
        public Knight(string name) : base(name)
        {
            hitCount = 0;
            Health = 500;
            Strength = 70;
        }

        public override int Attack()
        {
            hitCount++;
            int baseAttack = base.Attack();
            if (hitCount == 5)
            {
                baseAttack *= 2;
                hitCount = 0;
            }
            return baseAttack;
        }
        public override void TakeDamage(int incomingDamage)
        {
            int coef = Random.Shared.Next(20, 61);
            incomingDamage -= (coef * incomingDamage) / 100;
            base.TakeDamage(incomingDamage);
        }
    }
}
