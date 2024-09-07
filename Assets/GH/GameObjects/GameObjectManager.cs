using Assets.GH.GameObjects.Contracts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    class GameObjectManager : IGameObjectManager
    {
        private readonly Dictionary<PlayerState, IMoveable> _moveableMap = new();
        private readonly Rigidbody2D _rb;

        private PlayerState _playerState;

        public GameObjectManager(Rigidbody2D rb)
        {
            _playerState = PlayerState.Cube;
            _rb = rb;
        }

        public void AddMoveable(PlayerState state, GameObject[] raycasts = null)
        {
            if (_moveableMap.ContainsKey(state))
                return;

            switch (state)
            {
                case PlayerState.Cube:
                {
                    _moveableMap.Add(state, new Cube(_rb, 6f, 6f, 1f, raycasts));
                } break;

                case PlayerState.Ship:
                {
                    _moveableMap.Add(state, new Ship(_rb, 6f, 0.08f, 2f, 8f, 0.6f));
                } break;
            }
        }

        public void Update()
        {
            if (_moveableMap.ContainsKey(_playerState))
                _moveableMap[_playerState].Move();
        }

        public void TogglePlayerState()
            => _playerState = _playerState == PlayerState.Cube ? PlayerState.Ship : PlayerState.Cube;
    }
}
