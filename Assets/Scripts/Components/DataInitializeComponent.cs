using TankBattle.Elementary;
using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class DataInitializeComponent : MonoBehaviour, IDataInitializer
    {
        [SerializeField] private ScriptableObjectEventReceiver _eventReceiver;
        
        public void Initialize(ScriptableObject scriptableObject)
        {
            _eventReceiver.Call(scriptableObject);
        }
    }
}