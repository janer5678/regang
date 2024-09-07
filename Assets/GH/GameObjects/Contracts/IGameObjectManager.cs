using UnityEngine;

namespace Assets.GH.GameObjects.Contracts
{
    interface IGameObjectManager
    {
        void AddMoveable(PlayerState playerState, GameObject[] raycasts = null);
        void Move();
        void TogglePlayerState();
    }
}
