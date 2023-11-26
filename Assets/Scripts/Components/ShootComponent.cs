using Elementary;
using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class ShootComponent : MonoBehaviour, IShootComponent
    {
        [SerializeField] private EventReceiver _shootReceiver;
        
        public void Shoot()
        {
            _shootReceiver.Call();
        }
    }
}