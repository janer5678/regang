using System;
using GH.Scripts.Enums;
using GH.Scripts.GameObjects.Contracts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GH.Scripts.GameObjects
{
    class Cube : MonoBehaviour, IMoveable
    {
        private GameObject[] _raycasts;
        private Character _character;

        private bool _canJump;
        private bool _canDrop;

        public void Init(
            Rigidbody2D rb,
            float xSpeed,
            float ySpeed,
            float gravityScale,
            GameObject[] raycasts,
            Action<Directions> flipSprite,
            KeyCode ability1,
            KeyCode ability2,
            Character character)
        {
            _character = character;
            _raycasts = raycasts;

            _character.Init(rb, xSpeed, ySpeed, gravityScale, flipSprite, ability1, ability2);
        }

        public void Move()
        {
            _character.UpdateGravity();

            _character.RigidBody.velocity = new Vector2(0, _character.RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                _character.MoveHorizontally(-_character.SpeedX);
            if (Input.GetKey(KeyCode.RightArrow))
                _character.MoveHorizontally(_character.SpeedX);

            if (Input.GetKey(KeyCode.UpArrow) && _canJump)
            {
                _canJump = false;
                _canDrop = true;
                _character.RigidBody.velocity = new Vector2(_character.RigidBody.velocity.x, _character.SpeedY);
            }

            if (Input.GetKey(KeyCode.DownArrow) && _canDrop)
            {
                _canDrop = false;
                _character.RigidBody.velocity = new Vector2(_character.RigidBody.velocity.x, -_character.SpeedY * 1.1f);
            }

            foreach (var raycast in _raycasts)
            {
                var hit = Physics2D.Raycast(raycast.transform.position, -Vector2.up, 0.1f);

                if (hit)
                    _canJump = true;

                Debug.DrawRay(raycast.transform.position, -Vector2.up * 0.1f, Color.red);
            }
        }

        public void Destroy()
        {
            Destroy(this);
        }

        private void Dash()
        {

        }

        private void OnCollisionEnter2D(Collision2D other)
        {

        }
    }
}

// dash (touch somebody kills them)
// use ability turn into ship
