using System;
using System.Collections;
using System.Collections.Generic;
using GH.Scripts.Bomb;
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
        private Vector2 _originalScale;
        private HashSet<GameObject> invisibleBombs = new();

        private bool _canShrink = true;
        private bool _canDropBomb = true;

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

            _backToCubeTimer = gameObject.AddComponent<Timer>();
            _backToCubeTimer.Init(backToCubeTimeoutSecs, 
                () => {
                    _canShrink = true;
                    _canDropBomb = true;
                    transform.localScale = _originalScale;
                    BehaviourManager.SwitchPlayerMode(gameObject.transform.position);
                });

            _originalScale = transform.localScale;
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

            Abilities();
        }

        public void Move()
        {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x * xDeceleration, RigidBody.velocity.y);


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
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, Math.Min(RigidBody.velocity.y + ySpeed, yMaxVelocity));
                }
            }
            else if (StaticScript.player2character == 3)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, Math.Min(RigidBody.velocity.y + ySpeed, yMaxVelocity));
                }
            }
            else if (StaticScript.player3character == 3)
            {
                if (up > 0)
                {
                    RigidBody.velocity = new Vector2(RigidBody.velocity.x, Math.Min(RigidBody.velocity.y + ySpeed, yMaxVelocity));
                }
            }

        }

        public void Abilities()
        {
            if (StaticScript.player1character == 3 ||  StaticScript.player2character == 3)
            {
                if (Input.GetKey(BehaviourManager.abilityKey1) && _canShrink)
                {
                    // shrink own hitbox size
                    StartCoroutine(Shrink());
                }

                if (Input.GetKey(BehaviourManager.abilityKey2) && _canDropBomb)
                {
                    // drop bomb
                    StartCoroutine(DropBomb());
                }
            }
            else if (StaticScript.player3character == 3)
            {
                if (attack1 > 0 && _canShrink)
                {
                    // shrink own hitbox size
                    StartCoroutine(Shrink());
                }

                if (attack2 > 0  && _canDropBomb)
                {
                    // drop bomb
                    StartCoroutine(DropBomb());
                }
            }


            if (StaticScript.player1character == 3)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    foreach (var item in invisibleBombs)
                    {
                        StartCoroutine(item.GetComponent<BaseBomb>().Explode());
                    }

                    invisibleBombs.Clear();
                }
            }
            else if (StaticScript.player2character == 3)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    foreach (var item in invisibleBombs)
                    {
                        StartCoroutine(item.GetComponent<BaseBomb>().Explode());
                    }

                    invisibleBombs.Clear();
                }
            }
            else if (StaticScript.player3character == 3)
            {
                if (down > 0)
                {
                    foreach (var item in invisibleBombs)
                    {
                        StartCoroutine(item.GetComponent<BaseBomb>().Explode());
                    }

                    invisibleBombs.Clear();
                }
            }


        }

        private IEnumerator Shrink()
        {
            transform.localScale /= 2;
            _canShrink = false;

            yield return new WaitForSeconds(1);

            transform.localScale = _originalScale;
            _canShrink = true;
        }

        private IEnumerator DropBomb()
        {
            gameObject.tag = "wall";
            _canDropBomb = false;
            Instantiate(BehaviourManager.BombPrefab, transform.position, Quaternion.identity);
            var invisibleBomb = Instantiate(BehaviourManager.InvisibleBombPrefab, transform.position, Quaternion.identity);
            invisibleBombs.Add(invisibleBomb);

            yield return new WaitForSeconds(1);
            gameObject.tag = "player";
            _canDropBomb = true;
        }
    }
}
