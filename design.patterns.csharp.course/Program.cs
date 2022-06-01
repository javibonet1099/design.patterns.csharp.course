using Common;
using design.patterns.csharp.course.BattleFields;
using design.patterns.csharp.course.Facades;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    class Program
    {
        static void Main(string[] args)
        {

            //Testing template method
            TestBattlefields();

            // Blocked by singleton pattern
            //PrimaryPlayer p1 = new PrimaryPlayer()
            //{
            //    Name = "Playerone",
            //    Level = 1
            //};
            //PrimaryPlayer p2 = new PrimaryPlayer()
            //{
            //    Name = "PlayerTwo",
            //    Level = 2
            //};

            // Commented when we add the Factory pattern
            PrimaryPlayer player = PrimaryPlayer.Instance;
            Console.WriteLine($"{player.Name} - lvl {player.Level}");
            try
            {
                TestApiConnectionAsync().Wait();

                // Commented to test Decorators
                //Gameboard board = new Gameboard();
                //board.PlayArea(1).Wait();


                //TestDecorators();

                //TestComposite();

                // Strategy and Facade
                GameboardFacade gameboard = new GameboardFacade();
                gameboard.Play(player, 1).Wait();

                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to initialise game");
                Console.ReadKey();
            }
        }

        private static void TestBattlefields()
        {
            BattlefieldTemplate battlefield = new VolcanoBattlefield();
            Console.WriteLine(battlefield.Describe());
            Console.ReadKey();
        }

        private static async Task TestApiConnectionAsync()
        {
            int maxAttemps = 20;

            // Interval in milliseconds
            int attempInterval = 2000;

            using (var http = new HttpClient())
            {
                for (int i = 0; i < maxAttemps; i++)
                {
                    try
                    {
                        var response = await http.GetAsync("http://localhost:9913/api/cards");

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return;
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        Console.WriteLine("Lost connection to server. Attempting to re-connect");
                        Thread.Sleep(attempInterval);
                    }
                }

                throw new Exception("Failed to connect to server");
            }
        }

        private static void TestDecorators()
        {
            Card soldier = new Card("Soldier", 25, 20);
            soldier = new AttackDecorator(soldier, "Sword", 15);
            soldier = new AttackDecorator(soldier, "Amulet", 5);
            soldier = new DefenseDecorator(soldier, "Helmet", 10);
            soldier = new DefenseDecorator(soldier, "Heavy Armor", 45);
            Console.WriteLine($"Final stats: {soldier.Attack} / {soldier.Defense}");
        }

        private static void TestComposite()
        {
            CardDeck deck = new CardDeck();
            CardDeck attackDeck = new CardDeck();
            CardDeck defenseDeck = new CardDeck();

            attackDeck.Add(new Card("Basic Infantry Unit", 12, 15));
            attackDeck.Add(new Card("Advance Infantry Unit", 25, 18));
            attackDeck.Add(new Card("Cavarly Unit", 32, 24));

            defenseDeck.Add(new Card("Wooden Shield", 0, 6));
            defenseDeck.Add(new Card("Iron Shield", 0, 9));
            defenseDeck.Add(new Card("Shining Royal Armor", 0, 40));

            deck.Add(attackDeck);
            deck.Add(new Card("small Beast", 16, 3));
            deck.Add(new Card("High Elf Rogue", 22, 7));
            deck.Add(defenseDeck);

            Console.WriteLine(deck.Display());
        }
    }
}
