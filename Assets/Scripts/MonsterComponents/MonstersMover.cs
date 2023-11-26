using System.Collections;
using System.Collections.Generic;
using Entities;
using GameElements;
using TankBattle.Interfaces;
using TankBattle.Other;
using TankBattle.Services;
using UnityEngine;
using Zenject;

namespace TankBattle.MonsterComponents
{
    public class MonstersMover : IGameStartElement, IGameFinishElement
    {
        [Inject] private PlayerService _playerService;
        [Inject] private CoroutinePlayer _coroutinePlayer;

        private readonly List<IMoveToPointComponent> _movers;
        private Coroutine _coroutine;
        private IGetPositionComponent _positionComponent;

        public MonstersMover()
        {
            _movers = new List<IMoveToPointComponent>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _positionComponent = _playerService.GetCharacter().Get<IGetPositionComponent>();
            
            _coroutine = _coroutinePlayer.Run(Move());
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            if (_coroutine != null)
            {
                _coroutinePlayer.Stop(_coroutine);
            }
        }

        public void Add(IEntity entity)
        {
            _movers.Add(entity.Get<IMoveToPointComponent>());
        }

        public void Remove(IEntity entity)
        {
            if(entity.TryGet(out IMoveToPointComponent moveComponent))
                _movers.Remove(moveComponent);
        }

        private IEnumerator Move()
        {
            while (true)
            {
                foreach (var mover in _movers)
                {
                    var position = _positionComponent.GetPosition();
                    
                    mover.Move(position);
                }
                
                yield return null;
            }
        }
    }
}