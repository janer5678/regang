using Assets.GH.GameObjects.Contracts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    class GameObjectManager : IGameObjectManager
    {
        private readonly Dictionary<PlayerState, IMoveable> _moveableMap = new();
        private readonly Rigidbody2D _rb;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Dictionary<PlayerState, Sprite> _sprites;
        private readonly GameObject _gameObject;
        private readonly KeyCode _ability1;
        private readonly KeyCode _ability2;

        private PlayerState _playerState;

        public GameObjectManager(
            GameObject gameObject, 
            Rigidbody2D rb, 
            SpriteRenderer spriteRenderer, 
            Dictionary<PlayerState, Sprite> sprites, 
            KeyCode ability1, 
            KeyCode ability2)
        {
            _gameObject = gameObject;
            _playerState = PlayerState.Cube;
            _rb = rb;
            _spriteRenderer = spriteRenderer;
            _sprites = sprites;
            _ability1 = ability1;
            _ability2 = ability2;
        }

        public void AddMoveable(PlayerState state, GameObject[] raycasts = null)
        {
            if (_moveableMap.ContainsKey(state))
                return;

            switch (state)
            {
                case PlayerState.Cube:
                {
                    var cube = _gameObject.AddComponent<Cube>();
                    cube.Init(_rb, 6f, 6f, 1f, raycasts, FlipSprite, _ability1, _ability2);
                    _moveableMap.Add(state, cube);
                } break;

                case PlayerState.Ship:
                {
                    var ship = _gameObject.AddComponent<Ship>();
                    ship.Init(_rb, 6f, 0.08f, 2f, 8f, 0.6f, FlipSprite, _ability1, _ability2);
                    _moveableMap.Add(state, ship);
                } break;
            }
        }

        public void Update()
        {
            if (_moveableMap.ContainsKey(_playerState))
                _moveableMap[_playerState].Move();
        }

        public void TogglePlayerState()
        {
            _playerState = _playerState == PlayerState.Cube ? PlayerState.Ship : PlayerState.Cube;
            _spriteRenderer.sprite = _sprites[_playerState];
        }

        void FlipSprite(Directions directions)
        {
            if ((directions & Directions.Right) != Directions.None)
            {
                _spriteRenderer.flipX = false;
            }
            else if ((directions & Directions.Left) != Directions.None)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }
}
