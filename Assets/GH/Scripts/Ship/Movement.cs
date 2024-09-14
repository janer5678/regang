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

            if (Input.GetKey(KeyCode.DownArrow))
            {
                foreach (var item in invisibleBombs)
                {
                    StartCoroutine(item.GetComponent<BaseBomb>().Explode());
                }

                invisibleBombs.Clear();
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
