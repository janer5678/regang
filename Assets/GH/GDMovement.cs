using Assets.GH.GameObjects;
using Assets.GH.GameObjects.Contracts;
using UnityEngine;

namespace Assets.GH
{    
    public class GDMovement : MonoBehaviour
    {
        private PlayerState playerState;

        public GameObject[] raycasts;
        public float SPEED_X = 5.0f;
        public float SPEED_Y = 10.0f;

        private IGameObjectManager _gameObjectManager;

        // Start is called before the first frame update
        void Start()
        {
            var rb = GetComponent<Rigidbody2D>();
            var spriteRenderer = GetComponent<SpriteRenderer>();

            _gameObjectManager = new GameObjectManager(rb);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TogglePlayerState();
            }

            _gameObjectManager.AddMoveable(playerState, SPEED_X, SPEED_Y, raycasts);
            _gameObjectManager.Move(playerState);
        }

        void TogglePlayerState()
        {
            var nextPlayerState = playerState == PlayerState.Cube ? PlayerState.Ship : PlayerState.Cube;

            if (nextPlayerState == PlayerState.Cube)
            {
                SwitchToCube();
            }
            else
            {
                SwitchToShip();
            }
        }

        void SwitchToCube()
        {
            playerState = PlayerState.Cube;
            Debug.Log("Switched to cube");
        }

        void SwitchToShip()
        {
            playerState = PlayerState.Ship;
            Debug.Log("Switched to ship");
        }
    }
}
