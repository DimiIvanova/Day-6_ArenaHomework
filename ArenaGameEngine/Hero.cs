namespace ArenaGameEngine
{
    public class Hero
    {
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Strength { get; protected set; }
        public Hero(string name)
        {
            Name = name;
        }
        public bool IsAlive => Health > 0;
        public bool IsDead => !IsAlive;

        public virtual int Attack()
        {
            int coef = Random.Shared.Next(80, 121);
            return (coef * Strength) / 100;
        }
        public virtual void TakeDamage(int incomingDamage)
        {
            Health -= incomingDamage;
        }
    }
}
