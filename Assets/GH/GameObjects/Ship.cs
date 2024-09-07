using UnityEngine;

namespace Assets.GH.GameObjects
{
    class Ship : Moveable
    {
        const float MAX_Y_VELOCITY = 5.0f;
        const float X_DECELERATION = 0.6f;

        public Ship(Rigidbody2D rb, float xSpeed, float ySpeed, float gravityScale)
            : base(rb, xSpeed, ySpeed, gravityScale)
        {

        }

        public override void Move()
        {
            UpdateGravity();

            _rb.velocity = new Vector2(_rb.velocity.x * X_DECELERATION * Time.deltaTime, _rb.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-SPEED_X);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(SPEED_X);


            if (Input.GetKey(KeyCode.UpArrow))
            {
                var nextVelocityY = _rb.velocity.y + SPEED_Y;

                if (nextVelocityY > MAX_Y_VELOCITY) 
                    nextVelocityY = MAX_Y_VELOCITY;
                
                _rb.velocity = new Vector2(_rb.velocity.x, nextVelocityY);
            }
        }
    }
}
