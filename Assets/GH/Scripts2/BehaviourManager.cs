using UnityEngine;

namespace GH.Scripts2
{
    public class BehaviourManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] playerStates;
        private int _currentStateIndex;

        public Vector2 position;

        private void Start()
        {
            // The first in the list will always be the initially active player.
            for (int i = 1; i < playerStates.Length; i++)
            {
                playerStates[i].SetActive(false);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var nextIndex = (_currentStateIndex + 1) % playerStates.Length;

                playerStates[_currentStateIndex].SetActive(false);
                playerStates[nextIndex].SetActive(true);

                _currentStateIndex = nextIndex;
            }
        }
    }
}
