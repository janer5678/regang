using UnityEngine;

namespace Assets.GH.GameObjects
{
    class Cube : Moveable
    {
        private GameObject[] _raycasts;

        private bool canJump = false;
        private bool canDrop = false;

        public Cube(Rigidbody2D rb, float xSpeed, float ySpeed, GameObject[] raycasts) 
            : base(rb, xSpeed, ySpeed)
        {
            _raycasts = raycasts;
        }

        public override void Move()
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-SPEED_X);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(SPEED_X);

            if (Input.GetKey(KeyCode.UpArrow) && canJump)
            {
                canJump = false;
                canDrop = true;
                _rb.velocity = new Vector2(_rb.velocity.x, SPEED_Y);
            }

            if (Input.GetKey(KeyCode.DownArrow) && canDrop)
            {
                canDrop = false;
                _rb.velocity = new Vector2(_rb.velocity.x, -SPEED_Y * 1.1f);
            }

            foreach (var raycast in _raycasts)
            {
                RaycastHit2D hit = Physics2D.Raycast(raycast.transform.position, -Vector2.up, 0.1f);

                if (hit)
                    canJump = true;

                Debug.DrawRay(raycast.transform.position, -Vector2.up * 0.1f, Color.red);
            }
        }

        void MoveHorizontally(float speed)
            => _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }
}
