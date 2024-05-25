using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Shaman : Hero
    {
        public Shaman(string name) : base(name)
        {
            Health = 420;
            Strength = 88;
        }

        public override int Attack()
        {
            int baseAttack = base.Attack() + 20;
            int dice = Random.Shared.Next(0, 100);
            if (dice <= 20)//chance to heal for half the damage dealt
            {
                Health += baseAttack / 2; 

                if (Health > 350) Health = 350; // the health shouldnt exceed maximum
            }
            return baseAttack;
        }
    }
}
