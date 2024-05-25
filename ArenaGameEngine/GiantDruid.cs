using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class GiantDruid : Hero
    {
        public GiantDruid(string name) : base(name)//tank champion with weaker attacks but high health
        {
            Health = 695;
            Strength = 65;
        }
        public override int Attack()
        {
            int baseAttack = base.Attack();
            int dice = Random.Shared.Next(0, 100);
            if (dice <= 25)// 25% chance to double attack
            {
                baseAttack *= 2;
            }
            return baseAttack;
        }
        public override void TakeDamage(int incomingDamage)
        {
            int coef = Random.Shared.Next(10, 31);
            incomingDamage -= (coef * incomingDamage) / 100;
            base.TakeDamage(incomingDamage);
        }
    }
}
