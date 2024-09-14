using System.Collections;
using UnityEngine;

namespace GH.Scripts.Bomb
{
    public abstract class BaseBomb : MonoBehaviour
    {
        [SerializeField] protected float explosionSize;
        [SerializeField] protected float explosionRate;

        protected Rigidbody2D RigidBody;

        protected bool _isExploding;

        private void Start()
        {
            RigidBody = GetComponent<Rigidbody2D>();
        }

        public virtual IEnumerator Explode()
        {
            _isExploding = true;

            // assume scale.x and scale.y are always equal
            while (transform.localScale.x < explosionSize)
            {
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y) + Vector2.one * explosionRate;
                yield return new WaitForSeconds(0.02f);
            }

            Destroy(gameObject);
        }
    }
}
