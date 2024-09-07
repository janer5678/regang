using System;
using GH.Scripts.Enums;
using UnityEngine;

namespace GH.Scripts.GameObjects
{
    class Ship : Character
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

            RigidBody.velocity = new Vector2(RigidBody.velocity.x * _xDeceleration, RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-SpeedX);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(SpeedX);


            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Math.Max and Mathf.Max doesn't like me
                
                var nextVelocityY = RigidBody.velocity.y + SpeedY;

                if (nextVelocityY > _maxVelocityY)
                    nextVelocityY = _maxVelocityY;

                RigidBody.velocity = new Vector2(RigidBody.velocity.x, nextVelocityY);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
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
