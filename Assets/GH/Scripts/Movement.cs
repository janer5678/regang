using GH.Scripts.Enums;
using GH.Scripts.GameObjects;
using GH.Scripts.GameObjects.Contracts;
using UnityEngine;

namespace GH.Scripts
{    
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] raycasts;
        [SerializeField]
        private Sprite cubeSprite;
        [SerializeField]
        private Sprite shipSprite;
        [SerializeField]
        private KeyCode abilityKey1;
        [SerializeField]
        private KeyCode abilityKey2;

        private IGameObjectManager _gameObjectManager;

        // Start is called before the first frame update
        private void Start()
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

        private void Update()
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
