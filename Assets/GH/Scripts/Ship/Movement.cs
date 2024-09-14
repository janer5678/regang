using System;
using GH.Scripts.Timers;
using UnityEngine;

namespace GH.Scripts.Ship
{
    public class Movement : Player, IPlayer
    {
        [SerializeField] private float xDeceleration;
        [SerializeField] private float yMaxVelocity;
        [SerializeField] private float backToCubeTimeoutSecs;

        private Timer _backToCubeTimer;

        private new void Start()
        {
            base.Start();

            _backToCubeTimer = gameObject.AddComponent<Timer>();
            _backToCubeTimer.Init(backToCubeTimeoutSecs, BehaviourManager.SwitchPlayerMode);
        }

        private void FixedUpdate()
        {
            if (!_backToCubeTimer.IsRunning)
            {
                _backToCubeTimer.ResetTimer();
                _backToCubeTimer.StartTimer();
            }

            Move();

            RigidBody.MoveRotation(Quaternion.LookRotation(RigidBody.velocity));

            // auto fire missiles if possible
        }

        public void Move()
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

        public void Abilities()
        {
            if (Input.GetKey(BehaviourManager.abilityKey1))
            {
                // shrink own hitbox size
                transform.localScale /= 2;
            }

            if (Input.GetKey(BehaviourManager.abilityKey2))
            {
                // drop bomb
            }
        }
    }
}
