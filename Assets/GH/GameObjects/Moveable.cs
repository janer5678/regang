using Assets.GH.GameObjects.Contracts;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    abstract class Moveable : IMoveable
    {
        protected readonly Rigidbody2D _rb;
        protected readonly float _speedX;
        protected readonly float _speedY;
        protected readonly float _gravityScale;

        public Moveable(Rigidbody2D rb, float xSpeed = 1, float ySpeed = 1, float gravityScale = 1)
        {
            _rb = rb;
            _speedX = xSpeed;
            _speedY = ySpeed;
            _gravityScale = gravityScale;
        }

        public abstract void Move();

        protected void MoveHorizontally(float speed)
            => _rb.velocity = new Vector2(speed, _rb.velocity.y);

        protected void UpdateGravity()
            => _rb.gravityScale = _gravityScale;
    }
}
