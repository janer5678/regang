using Assets.GH.GameObjects.Contracts;
using System;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    abstract class Moveable : MonoBehaviour, IMoveable
    {
        protected Rigidbody2D _rb;
        protected float _speedX;
        protected float _speedY;
        protected float _gravityScale;
        protected Action<Directions> _flipSprite;
        protected KeyCode _ability1;
        protected KeyCode _ability2;

        public void Init(
            Rigidbody2D rb,
            float xSpeed,
            float ySpeed,
            float gravityScale,
            Action<Directions> flipSprite,
            KeyCode ability1,
            KeyCode ability2)
        {
            _rb = rb;
            _speedX = xSpeed;
            _speedY = ySpeed;
            _gravityScale = gravityScale;
            _flipSprite = flipSprite;
            _ability1 = ability1;
            _ability2 = ability2;
        }

        public abstract void Move();

        protected void MoveHorizontally(float speed)
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);

            if (_flipSprite is not null)
            {
                var direction = Directions.None;

                if (speed > 0)
                    direction |= Directions.Right;
                else if (speed < 0)
                    direction |= Directions.Left;

                _flipSprite(direction);
            }
        }

        protected void UpdateGravity()
            => _rb.gravityScale = _gravityScale;
    }
}
