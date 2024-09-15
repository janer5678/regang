using System.Collections;
using UnityEngine;

namespace GH.Scripts.Bomb
{
    public class Bomb : BaseBomb
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (RigidBody is null) return;

            RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

            if ((collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("Player"))&& collision.gameObject.name != "GH_Cube_Player")
            {
                Destroy(collision.gameObject);
            }

            if (!_isExploding)
            {
                StartCoroutine(Explode());
            }
        }
    }
}
