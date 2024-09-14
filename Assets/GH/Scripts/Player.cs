using UnityEngine;

namespace GH.Scripts
{
    public abstract class Player : MonoBehaviour
    {
        [SerializeField] protected float xSpeed;
        [SerializeField] protected float ySpeed;

        protected Rigidbody2D RigidBody;
        protected SpriteRenderer SpriteRenderer;
        protected BehaviourManager BehaviourManager;

        protected void Start()
        {
            RigidBody = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            BehaviourManager = GetComponentInParent<BehaviourManager>();
        }

        protected void MoveHorizontally(float speed)
        {
            RigidBody.velocity = new Vector2(speed, RigidBody.velocity.y);

            SpriteRenderer.flipX = speed switch
            {
                > 0 => false,
                < 0 => true,
                _ => SpriteRenderer.flipX
            };
        }

        protected void OnEnable()
        {
            if (BehaviourManager is not null)
            {
                transform.position = BehaviourManager.position;
            }
        }

        protected void OnDisable()
        {
            if (BehaviourManager is not null)
            {
                BehaviourManager.position = new Vector2(transform.position.x, transform.position.y);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
