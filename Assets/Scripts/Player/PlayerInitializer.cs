using GameElements;
using TankBattle.Interfaces;
using TankBattle.ScriptableObjects;
using TankBattle.Services;
using Zenject;

namespace TankBattle.Player
{
    public class PlayerInitializer : IGameInitElement
    {
        [Inject] private TankData _tankData;
        [Inject] private PlayerService _playerService;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _playerService.GetCharacter().Get<IDataInitializer>().Initialize(_tankData);
        }
    }
}