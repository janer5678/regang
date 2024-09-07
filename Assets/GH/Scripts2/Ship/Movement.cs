using UnityEngine;

namespace GH.Scripts2.Ship
{
    public class Movement : Player
    {
        [SerializeField] private float xDeceleration;
        [SerializeField] private float yMaxVelocity;

        private void Update()
        {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x * xDeceleration, RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-xSpeed);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(xSpeed);


            if (Input.GetKey(KeyCode.UpArrow))
            {
                var nextVelocityY = RigidBody.velocity.y + ySpeed;

                if (nextVelocityY > yMaxVelocity)
                    nextVelocityY = yMaxVelocity;

                RigidBody.velocity = new Vector2(RigidBody.velocity.x, nextVelocityY);
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
