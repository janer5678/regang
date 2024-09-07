using GH.Scripts.Enums;
using UnityEngine;

namespace GH.Scripts.GameObjects.Contracts
{
    interface IGameObjectManager
    {
        void AddMoveable(PlayerState playerState, GameObject[] raycasts = null);
        void Update();
        void SwitchPlayerState();
    }
}
