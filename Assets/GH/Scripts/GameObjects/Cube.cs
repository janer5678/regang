using System;
using GH.Scripts.Enums;
using UnityEngine;

namespace GH.Scripts.GameObjects
{
    class Cube : Character
    {
        private GameObject[] _raycasts;

        private bool canJump = false;
        private bool canDrop = false;

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

            _rb.velocity = new Vector2(0, _rb.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-_speedX);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(_speedX);

            if (Input.GetKey(KeyCode.UpArrow) && canJump)
            {
                canJump = false;
                canDrop = true;
                _rb.velocity = new Vector2(_rb.velocity.x, _speedY);
            }

            if (Input.GetKey(KeyCode.DownArrow) && canDrop)
            {
                canDrop = false;
                _rb.velocity = new Vector2(_rb.velocity.x, -_speedY * 1.1f);
            }

            foreach (var raycast in _raycasts)
            {
                RaycastHit2D hit = Physics2D.Raycast(raycast.transform.position, -Vector2.up, 0.1f);

                if (hit)
                    canJump = true;

                Debug.DrawRay(raycast.transform.position, -Vector2.up * 0.1f, Color.red);
            }
        }

        void Dash()
        {

        }
    }
}

// dash (touch somebody kills them)
// use ability turn into ship
