using UnityEngine;
using Assets.GH.Enums;

namespace Assets.GH.GameObjects.Contracts
{
    interface IGameObjectManager
    {
        void AddMoveable(PlayerState playerState, GameObject[] raycasts = null);
        void Update();
        void SwitchPlayerState();
    }
}
