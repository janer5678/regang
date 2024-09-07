// Unity version: 2022.3.24f1

using GH.Scripts.Enums;
using GH.Scripts.GameObjects;
using GH.Scripts.GameObjects.Contracts;
using UnityEngine;

namespace GH.Scripts
{    
    public class Movement : MonoBehaviour
    {
        public GameObject[] raycasts;
        public Sprite cubeSprite;
        public Sprite shipSprite;
        public KeyCode abilityKey1;
        public KeyCode abilityKey2;

        private IGameObjectManager _gameObjectManager;

        // Start is called before the first frame update
        void Start()
        {
            var rb = GetComponent<Rigidbody2D>();
            var spriteRenderer = GetComponent<SpriteRenderer>();

            _gameObjectManager = new GameObjectManager(
                gameObject,
                rb, 
                spriteRenderer, 
                new() 
                {
                    { PlayerState.Cube, cubeSprite },
                    { PlayerState.Ship, shipSprite }
                },
                abilityKey1,
                abilityKey2);
            
            _gameObjectManager.AddMoveable(PlayerState.Cube, raycasts);
            _gameObjectManager.AddMoveable(PlayerState.Ship); 
        }

        void Update()
        {
            // TODO: remove this, move to Cube and Ship to handle
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gameObjectManager.SwitchPlayerState();
            }

            _gameObjectManager.Update();
        }
    }
}
