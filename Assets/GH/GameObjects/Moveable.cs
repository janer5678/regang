using Assets.GH.GameObjects.Contracts;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    abstract class Moveable : IMoveable
    {
        protected readonly Rigidbody2D _rb;
        protected readonly float SPEED_X;
        protected readonly float SPEED_Y;
        protected readonly float GRAVITY_SCALE;

        public Moveable(Rigidbody2D rb, float xSpeed = 1, float ySpeed = 1, float gravityScale = 1)
        {
            _rb = rb;
            SPEED_X = xSpeed;
            SPEED_Y = ySpeed;
            GRAVITY_SCALE = gravityScale;
        }

        public abstract void Move();

        protected void MoveHorizontally(float speed)
            => _rb.velocity = new Vector2(speed, _rb.velocity.y);

        protected void UpdateGravity()
            => _rb.gravityScale = GRAVITY_SCALE;
    }
}
