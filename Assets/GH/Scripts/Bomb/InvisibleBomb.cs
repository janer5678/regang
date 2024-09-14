using System.Collections;
using UnityEngine;

namespace GH.Scripts.Bomb
{
    public class InvisibleBomb : BaseBomb
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (RigidBody is null) return;

            if (collision.gameObject.CompareTag("ground"))
            {
                RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
            }

            if (_isExploding && collision.gameObject.CompareTag("player"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
