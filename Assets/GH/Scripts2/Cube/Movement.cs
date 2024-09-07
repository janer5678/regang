using UnityEngine;

namespace GH.Scripts2.Cube
{
    public class Movement : Player
    {
        [SerializeField] private GameObject[] rayCasts;

        private bool _canJump;
        private bool _canDrop;

        private void Update()
        {
            RigidBody.velocity = new Vector2(0, RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-xSpeed);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(xSpeed);

            if (Input.GetKey(KeyCode.UpArrow) && _canJump)
            {
                _canJump = false;
                _canDrop = true;
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, ySpeed);
            }

            if (Input.GetKey(KeyCode.DownArrow) && _canDrop)
            {
                _canDrop = false;
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, -ySpeed * 1.1f);
            }

            foreach (var rayCast in rayCasts)
            {
                var hit = Physics2D.Raycast(rayCast.transform.position, -Vector2.up, 0.1f);

                if (hit)
                    _canJump = true;

                Debug.DrawRay(rayCast.transform.position, -Vector2.up * 0.1f, Color.red);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("CUBE HIT");
        }
    }
}

// dash (touch somebody kills them)
// use ability turn into ship
