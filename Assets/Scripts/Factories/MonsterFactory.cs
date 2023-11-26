using System.Collections.Generic;
using System.Linq;
using Entities;
using GameElements;
using TankBattle.Interfaces;
using TankBattle.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace TankBattle.Factories
{
    public class MonsterFactory : MonoBehaviour, IGameInitElement
    {
        [SerializeField] private UnityEntity _template;
        [SerializeField] private int _capacity;
        
        [Inject] private MonstersDataCollection _monstersDataCollection;
        [Inject] private IGameContext _gameContext;
        [Inject] private DiContainer _container;
        
        private readonly List<UnityEntity> _pool = new ();

        private void Awake()
        {
            Initialize(_template);

            foreach (var element in _pool)
            {
                _gameContext.RegisterElement(element.Get<IGameElementGroup>());
            }
        }

        void IGameInitElement.InitGame(IGameContext context)
        {
            foreach (var element in _pool)
            {
                element.Get<IDataInitializer>().Initialize(_monstersDataCollection.GetRandomData());
            }
        }

        public UnityEntity Get()
        {
            if (TryGetObject(out UnityEntity entity))
            {
                entity.gameObject.SetActive(true);
                
                return entity;
            }

            return null;
        }
        
        private void Initialize(UnityEntity prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                var spawned = _container.InstantiatePrefabForComponent<UnityEntity>(prefab, transform);
                spawned.gameObject.SetActive(false);
                spawned.name += i;

                _pool.Add(spawned);
            }
        }
        
        private bool TryGetObject(out UnityEntity result)
        {
            result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

            return result != null;
        }
    }
}