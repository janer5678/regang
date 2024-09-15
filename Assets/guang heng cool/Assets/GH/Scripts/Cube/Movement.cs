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
        private bool _touchedGround;
        Josh2Controls controls;
        float move;
        float up;
        float down;
        float attack1;
        float attack2;

        void Awake()
        {
            controls = new Josh2Controls();

            controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
            controls.Josh2.Movement.canceled += ctx => move = 0f;

            controls.Josh2.Up.performed += ctx => up = ctx.ReadValue<float>();
            controls.Josh2.Up.canceled += ctx => up = 0f;


            controls.Josh2.Down.performed += ctx => down = ctx.ReadValue<float>();
            controls.Josh2.Down.canceled += ctx => down = 0f;

            controls.Josh2.Attack1.performed += ctx => attack1 = ctx.ReadValue<float>();
            controls.Josh2.Attack1.canceled += ctx => attack1 = 0f;

            controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
            controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;

        }
        void OnEnable()
        {
            controls.Josh2.Enable();  // Ensure your action map is enabled
        }

        void OnDisable()
        {
            controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
        }

        private new void Start()
        {
            base.Start();

            _trailRenderer = gameObject.GetComponent<TrailRenderer>();

            _shipAbilityTimer = gameObject.AddComponent<Timer>();
            _shipAbilityTimer.Init(shipAbilityTimeoutSecs, () => _canTurnIntoShip = true);
        }

        private void FixedUpdate()
        {
            Abilities();
            Move();
        }

        public void Move()
        {
            if (_isDashing) return;

            RigidBody.velocity = new Vector2(0, RigidBody.velocity.y);

            if (StaticScript.player1character == 3)
            {

                if (Input.GetKey(KeyCode.LeftArrow))
                    MoveHorizontally(-xSpeed);
                if (Input.GetKey(KeyCode.RightArrow))
                    MoveHorizontally(xSpeed);
            }
            else if (StaticScript.player2character == 3)
            {
                if (Input.GetKey(KeyCode.A))
                    MoveHorizontally(-xSpeed);
                if (Input.GetKey(KeyCode.D))
                    MoveHorizontally(xSpeed);
            }
            else if (StaticScript.player3character == 3)
            {
                if (move < 0)
                    MoveHorizontally(-xSpeed);
                if (move > 0)
                    MoveHorizontally(xSpeed);
            }

            if (StaticScript.player1character == 3)
            {
                if (Input.GetKey(KeyCode.UpArrow) && _canJump)
                {
                    _canJump = false;
                    _canDrop = true;
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, ySpeed);
                }
            }
            else if (StaticScript.player2character == 3)
            {
                if (Input.GetKey(KeyCode.W) && _canJump)
                {
                    _canJump = false;
                    _canDrop = true;
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, ySpeed);
                }
            }
            else if (StaticScript.player3character == 3)
            {
                if (up >0 && _canJump)
                {
                    _canJump = false;
                    _canDrop = true;
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, ySpeed);
                }
            }

            if (StaticScript.player1character == 3)
            {
                if (Input.GetKey(KeyCode.DownArrow) && _canDrop)
                {
                    _canDrop = false;
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, -ySpeed * 1.1f);
                }
            }
            else if (StaticScript.player2character == 3)
            {
                if (Input.GetKey(KeyCode.S) && _canDrop)
                {
                    _canDrop = false;
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, -ySpeed * 1.1f);
                }
            }
            else if (StaticScript.player3character == 3)
            {
                if (down > 0 && _canDrop)
                {
                    _canDrop = false;
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, -ySpeed * 1.1f);
                }
            }

            foreach (var rayCast in rayCasts)
            {
                var hit = Physics2D.Raycast(rayCast.transform.position, -Vector2.up, 0.1f);

                if (hit)
                {
                    _canJump = true;
                    _touchedGround = true;
                }

                Debug.DrawRay(rayCast.transform.position, -Vector2.up * 0.1f, Color.red);
            }
        }

        private IEnumerator Dash()
        {
            var dashVelocity = Vector2.zero;

            if (StaticScript.player1character == 3)
            {
                if (Input.GetKey(KeyCode.LeftArrow)) dashVelocity += Vector2.left;
                if (Input.GetKey(KeyCode.RightArrow)) dashVelocity += Vector2.right;
                if (Input.GetKey(KeyCode.DownArrow)) dashVelocity += Vector2.down;
                if (Input.GetKey(KeyCode.UpArrow)) dashVelocity += Vector2.up;
            }
            else if (StaticScript.player2character == 3)
            {
                if (Input.GetKey(KeyCode.A)) dashVelocity += Vector2.left;
                if (Input.GetKey(KeyCode.D)) dashVelocity += Vector2.right;
                if (Input.GetKey(KeyCode.S)) dashVelocity += Vector2.down;
                if (Input.GetKey(KeyCode.W)) dashVelocity += Vector2.up;
            }
            else if (StaticScript.player3character == 3)
            {
                if (move < 0) dashVelocity += Vector2.left;
                if (move > 0) dashVelocity += Vector2.right;
                if (down > 0) dashVelocity += Vector2.down;
                if (up > 0) dashVelocity += Vector2.up;
            }


            if (dashVelocity == Vector2.zero)
                dashVelocity = SpriteRenderer.flipX ? Vector2.left : Vector2.right;

            _canDash = false;
            _isDashing = true;
            _trailRenderer.emitting = true;
            _touchedGround = false;

            var originalGravity = RigidBody.gravityScale;

            RigidBody.gravityScale = 0;
            RigidBody.velocity = dashVelocity * 15;

            BehaviourManager.SetInvincible(true);

            yield return new WaitForSeconds(0.15f);

            RigidBody.gravityScale = originalGravity;
            RigidBody.velocity /= 5;
            _isDashing = false;
            _trailRenderer.emitting = false;
            BehaviourManager.SetInvincible(false);

            yield return new WaitForSeconds(0.85f);
            _canDash = true;
        }

        public void Abilities()
        {
            if (_isDashing) return;

            // dash
            if (StaticScript.player1character == 3 || StaticScript.player2character == 3)
            {
                if (Input.GetKey(BehaviourManager.abilityKey1) && _canDash && _touchedGround)
                {
                    StartCoroutine(Dash());
                    return;
                }
            }
            else if (StaticScript.player3character == 3)
            {
                if (attack1 > 0 && _canDash && _touchedGround)
                {
                    StartCoroutine(Dash());
                    return;
                }
            }

            if (StaticScript.player1character == 3 || StaticScript.player2character == 3)
            {
                if (Input.GetKey(BehaviourManager.abilityKey2) && _canTurnIntoShip)
                {
                    _canDash = true;
                    _canTurnIntoShip = false;
                    _shipAbilityTimer.StartTimer();

                    BehaviourManager.SwitchPlayerMode(gameObject.transform.position);
                }
            }
            else if (StaticScript.player3character == 3)
            {
                if (attack2 > 0 && _canTurnIntoShip)
                {
                    _canDash = true;
                    _canTurnIntoShip = false;
                    _shipAbilityTimer.StartTimer();

                    BehaviourManager.SwitchPlayerMode(gameObject.transform.position);
                }
            }
                // turn into ship

        }
    }
}
