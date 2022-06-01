using Common;
using design.patterns.csharp.course.Proxies;
using design.patterns.csharp.course.Strategies;
using design.patterns.csharp.course.Observer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using design.patterns.csharp.course.Commands;

namespace design.patterns.csharp.course.Facades
{
    public class GameboardFacade
    {

        private PrimaryPlayer _player;

        private int _areaLevel;

        private HttpClient _http;

        private EnemyFactory _enemyFactory;

        private List<IEnemy> _enemies;

        private CardsProxy _cardsProxy;

        public GameboardFacade()
        {
            _cardsProxy = new CardsProxy();
        }

        public async Task Play(PrimaryPlayer player, int areaLevel)
        {
            this._player = player;
            this._areaLevel = areaLevel;
            this._enemies = new List<IEnemy>();
            
            ConfigurePlayerWeapon();

            // Removed due to Proxy pattern.
            //await AddPlayerCards();

            InitialiseEnemyFactory(this._areaLevel);
            LoadZombies(this._areaLevel);
            LoadWerewolves(this._areaLevel);
            LoadGiants(this._areaLevel);

            //Begin Playing Logic
        }
        private void ConfigurePlayerWeapon()
        {
            string input;

            int choice;

            while(true)
            {
                Console.WriteLine("Pick a weapon:");
                Console.WriteLine("1. Sword");
                Console.WriteLine("2. Fire Staff");
                Console.WriteLine("3. Ice Staff");

                input = Console.ReadLine();

                if (Int32.TryParse(input, out choice))
                {
                    if (choice == 1)
                    {
                        _player.Weapon = new Sword(15, 7);
                        break;
                    }
                    else if (choice == 2)
                    {
                        _player.Weapon = new FireStaff(12, 14);
                        break;
                    }
                    else if (choice == 3)
                    {
                        _player.Weapon = new IceStaff(5, 1);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        private async Task AddPlayerCards()
        {
            // This is without proxy pattern
            //using (_http = new HttpClient())
            //{
            //    var cardsJson = await _http.GetStringAsync("http://localhost:9913/api/cards");
            //    _player.Cards = JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson).ToArray();
            //}

            _player.Cards = (await _cardsProxy.GetCards()).ToArray();
        }

        private void InitialiseEnemyFactory(int areaLevel)
        {
            _enemyFactory = new EnemyFactory(areaLevel);
        }

        private void LoadZombies(int areaLevel)
        {
            int count;

            if (areaLevel == 1)
            {
                count = 15;
            }
            else if (areaLevel > 1 && areaLevel < 10)
            {
                count = 25;
            }
            else
            {
                count = 40;
            }

            for (int i = 0; i < count; i++)
            {
                this._enemies.Add(this._enemyFactory.SpawnZombie());
            }
        }

        private void LoadWerewolves(int areaLevel)
        {
            int count;

            if (areaLevel == 1)
            {
                count = 10;
            }
            else if (areaLevel > 1 && areaLevel < 10)
            {
                count = 18;
            }
            else
            {
                count = 25;
            }

            
            for (int i = 0; i < count; i++)
            {
                this._enemies.Add(this._enemyFactory.SpawnWerewolf());
            }
        }

        private void LoadGiants(int areaLevel)
        {
            int count = 0;

            if (areaLevel > 8)
            {
                count = 2;
            }

            for (int i = 0; i < count; i++)
            {
                this._enemies.Add(this._enemyFactory.SpawnWerewolf());
            }
        }

        //Starting strategy pattern
        private void StartTurns()
        {
            IEnemy currentEnemy = null;

            while (true)
            {
                if (currentEnemy == null)
                {
                    currentEnemy = _enemies[0];
                    _enemies.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("You won this level!");
                    break;
                }

                // Command pattern
                var commands = GetCommands(currentEnemy);

                foreach(var command in commands)
                {
                    command.Execute();

                    if (_player.Health <= 0 || currentEnemy.Health <= 0) {
                        break;
                    }
                }

            }

            ////Your turn
            //_player.Weapon.Use(currentEnemy);

            ////Enemy's turn
            //currentEnemy.Attack(_player);

            //int damage = currentEnemy.Attack(_player);

            //Modify with observer
            //_player.Health -= damage;
            // With observer patter
            //_player.Hit(damage);


            // Moved when we introduce observer
            //if (_player.Health < 20)
            //{
            //    new CriticalDamageIndicator().NotifyAboutDamage(_player.Health, damage);
            //}
            //else
            //{
            //    new RegularDamageIndicator().NotifyAboutDamage(_player.Health, damage);
            //}

            // Observer Patter
            //var regularObserver = new HealthChangedObserver(new RegularDamageIndicator());
            //var criticalObserver = new HealthChangedObserver(new CriticalDamageIndicator());

            //regularObserver.WatchPlayerHealth(_player);
            //criticalObserver.WatchPlayerHealth(_player);
            //Thread.Sleep(500);
        }

        private IEnumerable<ICommand> GetCommands(IEnemy enemy)
        {
            List <ICommand> commands = new List<ICommand>();

            commands.Add(new PlayerEnemyBattleCommand(_player, enemy));

            foreach(var card in _player.Cards)
            {
                commands.Add(new CardEnemyBattleCommand(card, enemy));
            }

            return commands;
        }
    }
}
