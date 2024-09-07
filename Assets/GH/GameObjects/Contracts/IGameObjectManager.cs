using UnityEngine;

namespace Assets.GH.GameObjects.Contracts
{
    interface IGameObjectManager
    {
        void AddMoveable(PlayerState playerState, float xSpeed, float ySpeed, GameObject[] raycasts = null);
        void Move(PlayerState playerState);
    }
}
