using GH.Scripts.Enums;

namespace GH.Scripts.GameObjects.Contracts
{
    interface IGameObjectManager
    {
        void AddMoveable(PlayerState playerState);
        void Update();
        void SwitchPlayerState();
    }
}
