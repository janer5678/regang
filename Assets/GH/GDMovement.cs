using Assets.GH.GameObjects;
using Assets.GH.GameObjects.Contracts;
using UnityEngine;

namespace Assets.GH
{    
    public class GDMovement : MonoBehaviour
    {
        public GameObject[] raycasts;

        private IGameObjectManager _gameObjectManager;

        // Start is called before the first frame update
        void Start()
        {
            var rb = GetComponent<Rigidbody2D>();
            var spriteRenderer = GetComponent<SpriteRenderer>();

            _gameObjectManager = new GameObjectManager(rb);
            _gameObjectManager.AddMoveable(PlayerState.Cube, raycasts);
            _gameObjectManager.AddMoveable(PlayerState.Ship); 
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gameObjectManager.TogglePlayerState();
            }

            _gameObjectManager.Update();
        }
    }
}
