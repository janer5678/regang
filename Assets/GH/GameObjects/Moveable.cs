using Assets.GH.GameObjects.Contracts;
using System;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    abstract class Moveable : IMoveable
    {
        protected readonly Rigidbody2D _rb;
        protected readonly float _speedX;
        protected readonly float _speedY;
        protected readonly float _gravityScale;
        private readonly Action<Directions> _flipSprite;

        public Moveable(
            Rigidbody2D rb, 
            float xSpeed, 
            float ySpeed, 
            float gravityScale,
            Action<Directions> flipSprite)
        {
            _rb = rb;
            _speedX = xSpeed;
            _speedY = ySpeed;
            _gravityScale = gravityScale;
            _flipSprite = flipSprite;
        }

        public abstract void Move();

        protected void MoveHorizontally(float speed)
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);

            if (_flipSprite is not null)
            {
                Directions direction;

                if (speed > 0)
                    direction = Directions.Right;
                else if (speed < 0)
                    direction = Directions.Left;
                else
                    direction = Directions.None;

                _flipSprite(direction);
            }
        }

        protected void UpdateGravity()
            => _rb.gravityScale = _gravityScale;
    }
}
