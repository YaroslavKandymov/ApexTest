using Entities;

namespace TankBattle.Services
{
    public class PlayerService
    {
        private IEntity _entity;

        public PlayerService(IEntity entity)
        {
            _entity = entity;
        }

        public IEntity GetCharacter()
        {
            return _entity;
        }
    }
}