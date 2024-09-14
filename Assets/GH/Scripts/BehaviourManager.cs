using UnityEngine;

namespace GH.Scripts
{
    public class BehaviourManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] playerStates;
        [SerializeField] public KeyCode abilityKey1;
        [SerializeField] public KeyCode abilityKey2;
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

        public void SwitchPlayerMode()
        {
            var nextIndex = (_currentStateIndex + 1) % playerStates.Length;

            playerStates[_currentStateIndex].SetActive(false);
            playerStates[nextIndex].SetActive(true);

            _currentStateIndex = nextIndex;
        }

        public void SetInvincible(bool invincible)
        {
            gameObject.tag = invincible ? "wall" : "player";
        }
    }
}
