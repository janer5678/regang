using System;
using GH.Scripts.Enums;
using GH.Scripts.GameObjects.Contracts;
using UnityEngine;

namespace GH.Scripts.GameObjects
{
    class Ship : MonoBehaviour, IMoveable
    {
        private float _maxVelocityY;
        private float _xDeceleration;
        private Character _character;

        public void Init(
            Rigidbody2D rb,
            float xSpeed,
            float ySpeed,
            float gravityScale,
            float maxVelocityY,
            float xDeceleration,
            Action<Directions> flipSprite,
            KeyCode ability1,
            KeyCode ability2,
            Character character)
        {
            _character = character;
            _maxVelocityY = maxVelocityY;
            _xDeceleration = xDeceleration;

            _character.Init(rb, xSpeed, ySpeed, gravityScale, flipSprite, ability1, ability2);
        }

        public void Move()
        {
            _character.UpdateGravity();

            _character.RigidBody.velocity = new Vector2(_character.RigidBody.velocity.x * _xDeceleration, _character.RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                _character.MoveHorizontally(-_character.SpeedX);
            if (Input.GetKey(KeyCode.RightArrow))
                _character.MoveHorizontally(_character.SpeedX);


            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Math.Max and Mathf.Max doesn't like me
                
                var nextVelocityY = _character.RigidBody.velocity.y + _character.SpeedY;

                if (nextVelocityY > _maxVelocityY)
                    nextVelocityY = _maxVelocityY;

                _character.RigidBody.velocity = new Vector2(_character.RigidBody.velocity.x, nextVelocityY);
            }
        }

        public void Destroy()
        {
            Destroy(this);
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
