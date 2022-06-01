using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    public class EnemyFactory
    {
        private int _areaLevel;

        public int AreaLevel { get => _areaLevel; }

        private Stack<Zombie> _zombiesPool = new Stack<Zombie>();
        private Stack<Werewolf> _werewolvesPool = new Stack<Werewolf>();
        private Stack<Giant> _giantsPool = new Stack<Giant>();

        public EnemyFactory(int areaLevel)
        {
            _areaLevel = areaLevel;
            PreLoadZombies();
            PreloadWerewolves();
            PreloadGiants();
        }

        public Werewolf SpawnWerewolf()
        {
            //if (areaLevel < 5)
            //{
            //    return new Werewolf(100, 12);
            //}
            //else
            //{
            //    return new Werewolf(100, 20);
            //}
            if (_werewolvesPool.Count > 0)
            {
                //FIFO
                return _werewolvesPool.Pop();
            }
            else
            {
                throw new Exception("Werewolves pool depleted");
            }
        }

        public Giant SpawnGiant()
        {
            //if (areaLevel < 8)
            //{
            //    return new Giant(100, 14);
            //}
            //else
            //{
            //    return new Giant(100, 32);
            //}
            if (_giantsPool.Count > 0)
            {
                //FIFO
                return _giantsPool.Pop();
            }
            else
            {
                throw new Exception("Giants pool depleted");
            }
        }

        public Zombie SpawnZombie()
        {
            if (_zombiesPool.Count > 0)
            {
                //FIFO
                return _zombiesPool.Pop();
            }
            else
            {
                throw new Exception("Zombies pool depleted");
            }
        }

        public void ReclaimZombie(Zombie zombie)
        {
            (int health, int level, int armor) = GetZombiesStatus(_areaLevel);
            zombie.Health = health;
            zombie.Armor = armor;

            _zombiesPool.Push(zombie); 
        }

        public void ReclaimWerewolf(Werewolf werewolf)
        {
            (int health, int level) = GetWerewolveStatus(_areaLevel);
            
            werewolf.Health = health;
            
            _werewolvesPool.Push(werewolf);
        }

        public void ReclaimGiant(Giant giant)
        {
            (int health, int level) = GetGiantsStatus(_areaLevel);
            giant.Health = health;
            
            _giantsPool.Push(giant);
        }

        private (int, int, int) GetZombiesStatus(int areaLevel)
        {
            int health,
                armor,
                level;

            if (areaLevel < 3)
            {
                health = 66;
                level = 2;
                armor = 15;
            }
            else if (areaLevel >= 3 && areaLevel < 10)
            {
                health = 66;
                level = 5;
                armor = 15;
            }
            else
            {
                health = 100;
                level = 8;
                armor = 15;
            }

            return (health, level, armor);
        }

        private (int, int) GetWerewolveStatus(int areaLevel)
        {
            int health,
                level;

            if (areaLevel < 5)
            {
                health = 100;
                level = 12;
            }
            else
            {
                health = 100;
                level = 20;
            }

            return (health, level);
        }

        private (int, int) GetGiantsStatus(int areaLevel)
        {
            int health,
                level;

            if (areaLevel < 8)
            {
                health = 100;
                level = 14;
            }
            else
            {
                health = 100;
                level = 32;
            }

            return (health, level);
        }

        private void PreLoadZombies()
        {
            int count;
            int health;
            int armor;
            int level;

            if (_areaLevel < 3)
            {
                count = 15;
                //health = 66;
                //level = 2;
                //armor = 15;
            }
            else if (_areaLevel >= 3 && _areaLevel < 10)
            {
                count = 50;
                //health = 66;
                //level = 5;
                //armor = 15;
            }
            else
            {
                count = 200;
                //health = 100;
                //level = 8;
                //armor = 15;
            }

            (health, level, armor) = GetZombiesStatus(_areaLevel);
                 
            for (int i = 0; i < count; i++)
            {
                _zombiesPool.Push(new Zombie(health, level, armor));
            }
        }

        private void PreloadWerewolves()
        {
            int count;
            int health;
            int level;

            if (_areaLevel < 5)
            {
                count = 15;
                //health = 100;
                //level = 12;
            }
            else
            {
                count = 50;
                //health = 100;
                //level = 20;
            }

            (health, level) = GetWerewolveStatus(_areaLevel);

            for (int i = 0; i < count; i++)
            {
                _werewolvesPool.Push(new Werewolf(health, level));
            }
        }

        private void PreloadGiants()
        {
            int count;
            int health;
            int level;

            if (_areaLevel < 8)
            {
                count = 50;
                //health = 100;
                //level = 14;
            }
            else
            {
                count = 50;
                //health = 100;
                //level = 32;
            }

            (health, level) = GetGiantsStatus(_areaLevel);

            for (int i = 0; i < count; i++)
            {
                _giantsPool.Push(new Giant(health, level));
            }
        }
    }
}
