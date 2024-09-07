using System;
using GH.Scripts.Enums;
using UnityEngine;

namespace GH.Scripts.GameObjects
{
    class Cube : Character
    {
        private GameObject[] _raycasts;

        private bool _canJump = false;
        private bool _canDrop = false;

        public void Init(
            Rigidbody2D rb,
            float xSpeed,
            float ySpeed,
            float gravityScale,
            GameObject[] raycasts,
            Action<Directions> flipSprite,
            KeyCode ability1,
            KeyCode ability2)
        {
            Init(rb, xSpeed, ySpeed, gravityScale, flipSprite, ability1, ability2);
            _raycasts = raycasts;
        }

        public override void Move()
        {
            UpdateGravity();

            RigidBody.velocity = new Vector2(0, RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-SpeedX);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(SpeedX);

            if (Input.GetKey(KeyCode.UpArrow) && _canJump)
            {
                _canJump = false;
                _canDrop = true;
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, SpeedY);
            }

            if (Input.GetKey(KeyCode.DownArrow) && _canDrop)
            {
                _canDrop = false;
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, -SpeedY * 1.1f);
            }

            foreach (var raycast in _raycasts)
            {
                var hit = Physics2D.Raycast(raycast.transform.position, -Vector2.up, 0.1f);

                if (hit)
                    _canJump = true;

                Debug.DrawRay(raycast.transform.position, -Vector2.up * 0.1f, Color.red);
            }
        }

        private void Dash()
        {

        }
    }
}

// dash (touch somebody kills them)
// use ability turn into ship
