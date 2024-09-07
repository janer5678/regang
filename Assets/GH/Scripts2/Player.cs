using UnityEngine;

namespace GH.Scripts2
{
    public class Player : MonoBehaviour
    {
        [SerializeField] protected float xSpeed;
        [SerializeField] protected float ySpeed;
        protected Rigidbody2D RigidBody;
        protected SpriteRenderer SpriteRenderer;

        private void Start()
        {
            RigidBody = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
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
    }
}
