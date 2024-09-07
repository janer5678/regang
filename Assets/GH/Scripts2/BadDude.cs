using UnityEngine;

namespace GH.Scripts2
{
    public class BadDude : Player
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector2(RigidBody.position.x - xSpeed * Time.deltaTime, RigidBody.position.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector2(RigidBody.position.x + xSpeed * Time.deltaTime, RigidBody.position.y);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector2(RigidBody.position.x, RigidBody.position.y - ySpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector2(RigidBody.position.x, RigidBody.position.y + ySpeed * Time.deltaTime);
            }
        }
    }
}
