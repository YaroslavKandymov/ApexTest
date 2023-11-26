using Elementary;
using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class RestartComponent : MonoBehaviour, IRestartComponent
    {
        [SerializeField] private EventReceiver _eventReceiver;
        
        public void Restart()
        {
            _eventReceiver.Call();
        }
    }
}