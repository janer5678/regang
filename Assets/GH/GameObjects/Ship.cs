using UnityEngine;

namespace Assets.GH.GameObjects
{
    class Ship : Moveable
    {
        private readonly float _maxVelocityY;
        private readonly float _xDeceleration;

        public Ship(Rigidbody2D rb, float xSpeed, float ySpeed, float gravityScale, float maxVelocityY, float xDeceleration)
            : base(rb, xSpeed, ySpeed, gravityScale)
        {
            _maxVelocityY = maxVelocityY;
            _xDeceleration = xDeceleration;
        }

        public override void Move()
        {
            UpdateGravity();

            _rb.velocity = new Vector2(_rb.velocity.x * _xDeceleration, _rb.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-_speedX);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(_speedX);


            if (Input.GetKey(KeyCode.UpArrow))
            {
                var nextVelocityY = _rb.velocity.y + _speedY;

                if (nextVelocityY > _maxVelocityY) 
                    nextVelocityY = _maxVelocityY;
                
                _rb.velocity = new Vector2(_rb.velocity.x, nextVelocityY);
            }
        }
    }
}
