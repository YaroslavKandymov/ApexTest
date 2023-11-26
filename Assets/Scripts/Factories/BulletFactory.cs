using GameElements;
using TankBattle.BulletComponents;
using TankBattle.Other;
using UnityEngine;

namespace TankBattle.Factories
{
    public class BulletFactory : ObjectPool<Bullet>, IGameInitElement
    {
        [SerializeField] private Bullet _template;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            Initialize(_template);
        }

        public Bullet Get()
        {
            if (TryGetObject(out Bullet bullet))
            {
                bullet.gameObject.SetActive(true);
                
                return bullet;
            }

            return null;
        }
    }
}