using System;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace GH.Scripts.Ship
{
    public class Movement : Player
    {
        [SerializeField] private float xDeceleration;
        [SerializeField] private float yMaxVelocity;

        private void Update()
        {
            Move();
        }

        private void FixedUpdate()
        {
            RigidBody.MoveRotation(Quaternion.LookRotation(RigidBody.velocity));
        }

        protected override void Move()
        {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x * xDeceleration, RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-xSpeed);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(xSpeed);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, Math.Min(RigidBody.velocity.y + ySpeed, yMaxVelocity));
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}

// auto fire missiles

// shrink hitbox but missiles size remains same
// drop bomb
