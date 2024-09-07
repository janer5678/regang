using System;
using GH.Scripts.Enums;
using GH.Scripts.GameObjects.Contracts;
using UnityEngine;

namespace GH.Scripts.GameObjects
{
    abstract class Character : MonoBehaviour, IMoveable
    {
        protected Rigidbody2D RigidBody;
        protected float SpeedX;
        protected float SpeedY;
        private float _gravityScale;
        private Action<Directions> _flipSprite;
        protected KeyCode AbilityKey1;
        protected KeyCode AbilityKey2;

        protected void Init(
            Rigidbody2D rb,
            float xSpeed,
            float ySpeed,
            float gravityScale,
            Action<Directions> flipSprite,
            KeyCode ability1,
            KeyCode ability2)
        {
            RigidBody = rb;
            SpeedX = xSpeed;
            SpeedY = ySpeed;
            _gravityScale = gravityScale;
            _flipSprite = flipSprite;
            AbilityKey1 = ability1;
            AbilityKey2 = ability2;
        }

        public abstract void Move();

        protected void MoveHorizontally(float speed)
        {
            RigidBody.velocity = new Vector2(speed, RigidBody.velocity.y);

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
            => RigidBody.gravityScale = _gravityScale;
    }
}
