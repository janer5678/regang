using System;
using GH.Scripts.Enums;
using GH.Scripts.GameObjects.Contracts;
using UnityEngine;

namespace GH.Scripts.GameObjects
{
    public abstract class Character : IMoveable
    {
        public Rigidbody2D RigidBody;
        public float SpeedX;
        public float SpeedY;
        private float _gravityScale;
        private Action<Directions> _flipSprite;
        public KeyCode AbilityKey1;
        public KeyCode AbilityKey2;

        public void Init(
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
        public abstract void Destroy();

        public void MoveHorizontally(float speed)
        {
            RigidBody.velocity = new Vector2(speed, RigidBody.velocity.y);

            if (_flipSprite is not null)
            {
                var direction = Directions.None;

                direction |= speed switch
                {
                    > 0 => Directions.Right,
                    < 0 => Directions.Left,
                    _ => Directions.None
                };

                _flipSprite(direction);
            }
        }

        public void UpdateGravity()
            => RigidBody.gravityScale = _gravityScale;
    }
}
