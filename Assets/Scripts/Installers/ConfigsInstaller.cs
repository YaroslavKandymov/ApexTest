using TankBattle.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace TankBattle.Installers
{
    [CreateAssetMenu(fileName = "new ConfigsInstaller", menuName = "StaticData/ConfigsInstaller", order = 0)]
    public class ConfigsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private MonstersDataCollection _monstersDataCollection;
        [SerializeField] private TankData _tankData;
        
        public override void InstallBindings()
        {
            BindMonsterCollection();
            BindTankData();
        }

        private void BindMonsterCollection()
        { 
            Container.BindInstance(_monstersDataCollection);
        }
        
        private void BindTankData()
        { 
            Container.BindInstance(_tankData);
        }
    }
}