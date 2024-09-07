using System;
using UnityEngine;

namespace Assets.GH.GameObjects
{
    class Ship : Moveable
    {
        public Ship(Rigidbody2D rb, float xSpeed, float ySpeed) 
            : base(rb, xSpeed, ySpeed)
        {
            
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
