using Assets.GH.GameObjects.Contracts;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    abstract class Moveable : IMoveable
    {
        protected readonly Rigidbody2D _rb;
        protected readonly float SPEED_X;
        protected readonly float SPEED_Y;

        public Moveable(Rigidbody2D rb, float xSpeed = 1, float ySpeed = 1)
        {
            _rb = rb;
            SPEED_X = xSpeed;
            SPEED_Y = ySpeed;
        }
        
        public abstract void Move();
    }
}
