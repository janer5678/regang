using Assets.GH.GameObjects.Contracts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    class GameObjectManager : IGameObjectManager
    {
        private readonly Dictionary<PlayerState, IMoveable> _moveableMap = new();
        private readonly Rigidbody2D _rb;

        public GameObjectManager(Rigidbody2D rb)
        {
            _rb = rb;
        }

        public void AddMoveable(PlayerState state, float xSpeed, float ySpeed, GameObject[] raycasts = null)
        {
            if (_moveableMap.ContainsKey(state))
                return;

            switch (state)
            {
                case PlayerState.Cube:
                {
                    _moveableMap.Add(state, new Cube(_rb, xSpeed, ySpeed, raycasts));
                } break;

                case PlayerState.Ship:
                {
                    _moveableMap.Add(state, new Ship(_rb, xSpeed, ySpeed));
                } break;
            }
        }

        public void Move(PlayerState playerState)
        {
            if (_moveableMap.ContainsKey(playerState))
                _moveableMap[playerState].Move();
        }
    }
}
