using GameElements;
using UnityEngine;
using Zenject;

namespace TankBattle.Mechanics
{
    public class CameraInitializeMechanic : MonoBehaviour, IGameInitElement
    {
        [SerializeField] private Transform _parent;
        
        [Inject] private Camera _camera;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _camera.transform.SetParent(_parent);
        }
    }
}