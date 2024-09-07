using System.Collections.Generic;
using GH.Scripts.Enums;
using GH.Scripts.GameObjects.Contracts;
using UnityEngine;

namespace GH.Scripts.GameObjects
{
    class GameObjectManager : IGameObjectManager
    {
        private readonly Dictionary<PlayerState, IMoveable> _characterMap = new();
        private readonly Rigidbody2D _rb;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Dictionary<PlayerState, Sprite> _sprites;
        private readonly GameObject _gameObject;
        private readonly KeyCode _ability1;
        private readonly KeyCode _ability2;
        private readonly GameObject[] _raycasts;

        private PlayerState _playerState;
        private IMoveable _moveableComponent;

        public GameObjectManager(
            GameObject gameObject, 
            Rigidbody2D rb, 
            SpriteRenderer spriteRenderer, 
            Dictionary<PlayerState, Sprite> sprites, 
            KeyCode ability1, 
            KeyCode ability2,
            GameObject[] raycasts)
        {
            _gameObject = gameObject;
            _playerState = PlayerState.Cube;
            _rb = rb;
            _spriteRenderer = spriteRenderer;
            _sprites = sprites;
            _ability1 = ability1;
            _ability2 = ability2;
            _raycasts = raycasts;
        }

        public void AddMoveable(PlayerState state)
        {
            if (_characterMap.ContainsKey(state))
                return;

            switch (state)
            {
                case PlayerState.Cube:
                {
                    CreateCube();
                } break;

                case PlayerState.Ship:
                {
                    CreateShip();
                } break;
            }
        }

        private IMoveable CreateCube()
        {
            var cube = _gameObject.AddComponent<Cube>();
            var character = new CharacterImpl();
            cube.Init(_rb, 6f, 6f, 1f, _raycasts, FlipSprite, _ability1, _ability2, character);

            if (!_characterMap.TryAdd(PlayerState.Cube, cube))
            {
                // _characterMap.Add(PlayerState.Cube, cube);
                _characterMap[PlayerState.Cube] = cube;
            }

            return cube;
        }

        private IMoveable CreateShip()
        {

            var ship = _gameObject.AddComponent<Ship>();
            var character = new CharacterImpl();
            ship.Init(_rb, 6f, 0.08f, 2f, 8f, 0.6f, FlipSprite, _ability1, _ability2, character);

            if (!_characterMap.TryAdd(PlayerState.Ship, ship))
            {
                // _characterMap.Add(PlayerState.Ship, ship);
                _characterMap[PlayerState.Ship] = ship;
            }

            return ship;
        }

        public void Update()
        {
            foreach (var character in _characterMap.Values)
            {
                character.Destroy();
            }

            var moveable = _playerState switch
            {
                PlayerState.Cube => CreateCube(),
                PlayerState.Ship => CreateShip(),
                _ => null
            };

            // if (_characterMap.TryGetValue(_playerState, out var moveable))
            // {
            //     moveable.Enable();
            //     moveable.Move();
            // }

            moveable?.Move();
        }

        public void SwitchPlayerState()
        {
            _playerState = _playerState == PlayerState.Cube ? PlayerState.Ship : PlayerState.Cube;
            _spriteRenderer.sprite = _sprites[_playerState];
        }

        private void FlipSprite(Directions directions)
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
