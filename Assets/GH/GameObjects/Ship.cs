using System;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    class Ship : Moveable
    {
        private float _maxVelocityY;
        private float _xDeceleration;

        public void Init(
            Rigidbody2D rb,
            float xSpeed,
            float ySpeed,
            float gravityScale,
            float maxVelocityY,
            float xDeceleration,
            Action<Directions> flipSprite,
            KeyCode ability1,
            KeyCode ability2)
        {
            Init(rb, xSpeed, ySpeed, gravityScale, flipSprite, ability1, ability2);
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
                // Math.Max and Mathf.Max doesn't like me
                
                var nextVelocityY = _rb.velocity.y + _speedY;

                if (nextVelocityY > _maxVelocityY)
                    nextVelocityY = _maxVelocityY;

                _rb.velocity = new Vector2(_rb.velocity.x, nextVelocityY);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("player"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

// auto fire missiles

// shrink hitbox but missiles size remains same
// drop bomb
