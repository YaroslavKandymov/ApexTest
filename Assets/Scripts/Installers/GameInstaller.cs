using Entities;
using GameElements;
using TankBattle.Factories;
using TankBattle.InputComponents;
using TankBattle.MonsterComponents;
using TankBattle.Other;
using TankBattle.Player;
using TankBattle.Services;
using UnityEngine;
using Zenject;

namespace TankBattle.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CoroutinePlayer _coroutinePlayer;
        [SerializeField] private UnityEntity _player;
        [SerializeField] private MonsterFactory _monsterFactory;
        [SerializeField] private BulletFactory _bulletFactory;
        [SerializeField] private KeyboardShootInput _keyboardShootInput;
        [SerializeField] private KeyboardSwitchWeaponInput _keyboardSwitchWeaponInput;
        [SerializeField] private MonsterSpawner _monsterSpawner;

        private IGameContext _gameContext;

        public override void InstallBindings()
        {
            BindGameContext();
            BindCoroutinePlayer();
            BindCamera();
            BindKeyboardAxisInput();
            BindBulletFactory();
            BindDeathService();
            BindPlayerService();
            BindPlayerMover();
            BindPlayerInitializer();
            BindKeyboardShootInput();
            BindKeyboardSwitchWeaponInput();
            BindPlayerShooter();
            BindPlayerWeaponSwitcher();
            BindMonstersMover();
            BindMonsterFactory();
            BindMonsterSpawner();
            BindGameFinishService();
        }

        private void BindGameContext()
        {
            _gameContext = new GameContext();

            Container
                .Bind<IGameContext>()
                .FromInstance(_gameContext)
                .AsSingle();
        }

        private void BindCamera()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();
        }

        private void BindCoroutinePlayer()
        {
            var coroutinePlayer = Container.InstantiatePrefabForComponent<CoroutinePlayer>(_coroutinePlayer);

            Container.BindInstance(coroutinePlayer);
        }

        private void BindKeyboardAxisInput()
        {
            Container
                .Bind<KeyboardAxisInput>()
                .AsSingle();

            _gameContext.RegisterElement(Container.Resolve<KeyboardAxisInput>());
        }

        private void BindKeyboardShootInput()
        {
            var input = Container.InstantiatePrefabForComponent<KeyboardShootInput>(_keyboardShootInput);
            
            Container
                .Bind<KeyboardShootInput>()
                .FromInstance(input.GetComponent<KeyboardShootInput>())
                .AsSingle();

            _gameContext.RegisterElement(Container.Resolve<KeyboardShootInput>());
        }

        private void BindKeyboardSwitchWeaponInput()
        {
            var input = Container.InstantiatePrefabForComponent<KeyboardSwitchWeaponInput>(_keyboardSwitchWeaponInput);

            Container
                .Bind<KeyboardSwitchWeaponInput>()
                .FromInstance(input.GetComponent<KeyboardSwitchWeaponInput>())
                .AsSingle();
 
            _gameContext.RegisterElement(Container.Resolve<KeyboardSwitchWeaponInput>());
        }

        private void BindPlayerMover()
        {
            Container
                .Bind<PlayerMover>()
                .AsSingle();
            
            _gameContext.RegisterElement(Container.Resolve<PlayerMover>());
        }

        private void BindPlayerService()
        {
            var player = Container.InstantiatePrefabForComponent<UnityEntity>(_player);

            var service = new PlayerService(player);

            Container
                .Bind<PlayerService>()
                .FromInstance(service)
                .AsSingle();
            
            _gameContext.RegisterElement(player.Get<IGameElementGroup>());
        }

        private void BindPlayerInitializer()
        {
            Container
                .Bind<PlayerInitializer>()
                .AsSingle();
            
            _gameContext.RegisterElement(Container.Resolve<PlayerInitializer>());
        }

        private void BindMonsterFactory()
        {
            var factory = Container.InstantiatePrefabForComponent<MonsterFactory>(_monsterFactory);

            Container
                .Bind<MonsterFactory>()
                .FromInstance(factory)
                .AsSingle();
            
            _gameContext.RegisterElement(factory);
        }

        private void BindPlayerShooter()
        {
            Container
                .Bind<PlayerShooter>()
                .AsSingle();
            
            _gameContext.RegisterElement(Container.Resolve<PlayerShooter>());
        }

        private void BindPlayerWeaponSwitcher()
        {
            Container
                .Bind<PlayerWeaponSwitcher>()
                .AsSingle();
            
            _gameContext.RegisterElement(Container.Resolve<PlayerWeaponSwitcher>());
        }

        private void BindBulletFactory()
        {
            var factory = Container.InstantiatePrefabForComponent<BulletFactory>(_bulletFactory);

            Container
                .Bind<BulletFactory>()
                .FromInstance(factory)
                .AsSingle();
            
            _gameContext.RegisterElement(factory);
        }

        private void BindMonstersMover()
        {
            Container
                .Bind<MonstersMover>()
                .AsSingle();
            
            _gameContext.RegisterElement(Container.Resolve<MonstersMover>());
        }

        private void BindDeathService()
        {
            Container
                .Bind<DeathService>()
                .AsSingle();
        }

        private void BindMonsterSpawner()
        {
            Container
                .Bind<MonsterSpawner>()
                .FromInstance(_monsterSpawner)
                .AsSingle();
            
            _gameContext.RegisterElement(_monsterSpawner);
        }

        private void BindGameFinishService()
        {
            Container
                .Bind<GameFinishService>()
                .AsSingle();
            
            _gameContext.RegisterElement(Container.Resolve<GameFinishService>());
        }
    }
}