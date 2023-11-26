using System.Collections;
using System.Collections.Generic;
using Entities;
using GameElements;
using TankBattle.Factories;
using TankBattle.Interfaces;
using TankBattle.Services;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace TankBattle.MonsterComponents
{
    public class MonsterSpawner : MonoBehaviour, IGameInitElement, IGameStartElement, IGameFinishElement
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private int _maxCount;
        [SerializeField] private float _spawnDelay;

        [Inject] private MonsterFactory _monsterFactory;
        [Inject] private MonstersMover _monstersMover;
        [Inject] private DeathService _deathService;

        private readonly List<IEntity> _monsters = new();

        private WaitForSeconds _seconds;
        private Coroutine _coroutine;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _deathService.Dead += OnDead;
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _seconds = new WaitForSeconds(_spawnDelay);
            
            StartWork();
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _deathService.Dead -= OnDead;
            
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        private void OnDead(IEntity entity)
        {
            _monstersMover.Remove(entity);
        }

        private void StartWork()
        {
            _coroutine = StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_monsters.Count < _maxCount)
                {
                    var monster = _monsterFactory.Get();

                    if (monster != null)
                    {
                        monster.Get<IRestartComponent>().Restart();
                        monster.Get<ISetPositionComponent>().Set(GetRandomPoint());

                        _monstersMover.Add(monster);
                    }

                    yield return _seconds;
                }
            }
        }

        private Vector3 GetRandomPoint()
        {
            var random = new Random();
            
            return _spawnPoints[random.Next(0, _spawnPoints.Length - 1)].position;
        }
    }
}