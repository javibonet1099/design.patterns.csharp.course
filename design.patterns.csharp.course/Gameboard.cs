using Common;
using design.patterns.csharp.course.Adapters;
using design.patterns.csharp.course.Facades;
using design.patterns.csharp.course.LibraryFaked;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    public class Gameboard
    {
        private PrimaryPlayer _player;
        private GameboardFacade _gameboardFacade;
        
        public Gameboard()
        {
            _player = PrimaryPlayer.Instance;
            //Adding loose coupling
            //_player.Weapon = new Sword(12, 8);

            this._gameboardFacade = new GameboardFacade();
        }

        public async Task PlayArea(int level)
        {
            // spawn some enemies
            // as we are using dependency injection we don't need this
            //if (level == 1)
            //{
            //    _player.Cards = (await FetchCardsAsync()).ToArray();
            //    Console.WriteLine("Ready to play Level 1?");
            //    Console.ReadKey();
            //    PlayFirstLevel();
            //}
            //else 
            
            if (level == -1)
            {
                Console.WriteLine("Play special level?");
                Console.ReadKey();
                PlaySpecialLevel();
            }
            else
            {
                await this._gameboardFacade.Play(_player, level);
            }
        }

        private void PlaySpecialLevel()
        {
            _player.Weapon = new WeaponAdapter(new Blaster(20, 15, 15));
        }

        // We remove this due to the fact that we added a facade to 
        // wrap all the necessary methods to play.
        //private void PlayFirstLevel()
        //{
        //    const int currentLevel = 1;

        //    EnemyFactory factory = new EnemyFactory(currentLevel);

        //    List<IEnemy> enemies = new List<IEnemy>();

        //    for (int i=0; i < 10; i++)
        //    {
        //        enemies.Add(factory.SpawnZombie());
        //    }

        //    for (int i = 0; i < 3; i++)
        //    {
        //        enemies.Add(factory.SpawnWerewolf());
        //    }

        //    foreach (var enemy in enemies)
        //    {
        //        //Loose coupling
        //        while(enemy.Health > 0 || _player.Health > 0)
        //        {
        //            _player.Weapon.Use(enemy);
        //            enemy.Attack(_player);
        //        }
        //    }
        //}

        //private async Task<IEnumerable<Card>> FetchCardsAsync()
        //{
        //    using (var http = new HttpClient())
        //    {
        //        var cardsJson = await http.GetStringAsync("http://localhost:9913/api/cards");
        //        return JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson);
        //    }
        //}
    }
}
