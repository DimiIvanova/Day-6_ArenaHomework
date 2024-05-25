using ArenaGameEngine;

namespace ArenaGameConsole
{
    class ConsoleGameEventListener : GameEventListener
    {
        public override void GameRound(Hero attacker, Hero defender, int attack)
        {
            string message = $"{attacker.Name} attacked {defender.Name} for {attack} points";
            if (defender.IsAlive)
            {
                message = message + $" but {defender.Name} survived.";
            }
            else
            {
                message = message + $" and {defender.Name} died.";
            }
            Console.WriteLine(message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight("Sir John");
            Rogue rogue = new Rogue("Slim Shady");

            Shaman shaman = new Shaman("Baroness Vashj");
            GiantDruid gdruid = new GiantDruid("C'Thun");

            Arena arena = new Arena(knight, rogue);
            arena.EventListener = new ConsoleGameEventListener();

            Console.WriteLine("Battle between Knight and Rogue begins.");
            Hero winner1 = arena.Battle();
            Console.WriteLine($"Battle ended. Winner is: {winner1.Name}");

            arena = new Arena(shaman, gdruid);
            arena.EventListener = new ConsoleGameEventListener(); // Second battle
            Console.WriteLine("\nBattle between Shaman and GiantDruid begins.");
            Hero winner2 = arena.Battle();
            Console.WriteLine($"Battle ended. Winner is: {winner2.Name}");

            //I had an idea to start one final battle between the winner from battle 1 and the winner from battle 2
            Console.WriteLine("\nFinal Battle between the winners begins.");
            arena = new Arena(winner1, winner2);

            arena.EventListener = new ConsoleGameEventListener(); // Final battle
            Hero finalWinner = arena.Battle();
            Console.WriteLine($"Final Battle ended! The ultimate winner is: {finalWinner.Name}");

            Console.ReadLine();
        }
    }
}
