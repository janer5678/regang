using System.Collections;
using GH.Scripts.Timers;
using UnityEngine;

namespace GH.Scripts.Cube
{
    public class Movement : Player, IPlayer
    {
        [SerializeField] private GameObject[] rayCasts;
        [SerializeField] private float shipAbilityTimeoutSecs;
        [SerializeField] private float dashAbilityTimeoutSecs;
        private TrailRenderer _trailRenderer;

        private Timer _shipAbilityTimer;

        private bool _canJump;
        private bool _canDrop;
        private bool _canTurnIntoShip = true;
        private bool _canDash = true;

        private bool _isDashing;

        private new void Start()
        {
            base.Start();

            _trailRenderer = gameObject.GetComponent<TrailRenderer>();

            _shipAbilityTimer = gameObject.AddComponent<Timer>();
            _shipAbilityTimer.Init(shipAbilityTimeoutSecs, () => _canTurnIntoShip = true);
        }

        private void FixedUpdate()
        {
            if (_isDashing)
                return;

            Abilities();
            Move();
        }

        public void Move()
        {
            RigidBody.gravityScale = 1;
            RigidBody.velocity = new Vector2(0, RigidBody.velocity.y);

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveHorizontally(-xSpeed);
            if (Input.GetKey(KeyCode.RightArrow))
                MoveHorizontally(xSpeed);

            if (Input.GetKey(KeyCode.UpArrow) && _canJump)
            {
                _canJump = false;
                _canDrop = true;
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, ySpeed);
            }

            if (Input.GetKey(KeyCode.DownArrow) && _canDrop)
            {
                _canDrop = false;
                RigidBody.velocity = new Vector2(RigidBody.velocity.x, -ySpeed * 1.1f);
            }

            foreach (var rayCast in rayCasts)
            {
                var hit = Physics2D.Raycast(rayCast.transform.position, -Vector2.up, 0.1f);

                if (hit)
                    _canJump = true;

                Debug.DrawRay(rayCast.transform.position, -Vector2.up * 0.1f, Color.red);
            }
        }

        private IEnumerator Dash()
        {
            _canDash = false;
            _isDashing = true;
            _trailRenderer.emitting = true;

            var originalGravity = RigidBody.gravityScale;

            var dashVelocity = Vector2.zero;
            const int xScale = 20;

            if (Input.GetKey(KeyCode.LeftArrow)) dashVelocity += Vector2.left * xScale;
            if (Input.GetKey(KeyCode.RightArrow)) dashVelocity += Vector2.right * xScale;
            if (Input.GetKey(KeyCode.DownArrow)) dashVelocity += Vector2.down;
            if (Input.GetKey(KeyCode.UpArrow)) dashVelocity += Vector2.up;

            Debug.Log(dashVelocity);

            RigidBody.gravityScale = 0;
            RigidBody.velocity = dashVelocity * 15;

            yield return new WaitForSeconds(0.15f);

            RigidBody.gravityScale = originalGravity;
            RigidBody.velocity /= 5;
            _isDashing = false;
            _trailRenderer.emitting = false;

            yield return new WaitForSeconds(0.85f);
            _canDash = true;
        }

        public void Abilities()
        {
            // dash
            if (Input.GetKey(BehaviourManager.abilityKey1) && _canDash)
            {
                StartCoroutine(Dash());
            }

            // turn into ship
            if (Input.GetKey(BehaviourManager.abilityKey2) && _canTurnIntoShip)
            {
                _canTurnIntoShip = false;
                _shipAbilityTimer.StartTimer();

                BehaviourManager.SwitchPlayerMode();
            }
        }
    }
}
