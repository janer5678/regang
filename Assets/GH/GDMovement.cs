using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDMovement : MonoBehaviour
{
    private enum PlayerState
    {
        Cube,
        Ship
    }

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool canJump = false;
    private bool canDrop = false;
    private PlayerState playerState;

    public GameObject[] raycasts;
    public float SPEED_X = 5.0f;
    public float SPEED_Y = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePlayerState();
        }

        if (playerState == PlayerState.Cube)
        {
            CubeMovement();
        }
        else
        {
            ShipMovement();
        }
    }

    void CubeMovement()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow))
            MoveHorizontally(-SPEED_X);
        if (Input.GetKey(KeyCode.RightArrow))
            MoveHorizontally(SPEED_X);

        if (Input.GetKey(KeyCode.UpArrow) && canJump)
        {
            canJump = false;
            canDrop = true;
            rb.velocity = new Vector2(rb.velocity.x, SPEED_Y);
        }

        if (Input.GetKey(KeyCode.DownArrow) && canDrop)
        {
            canDrop = false;
            rb.velocity = new Vector2(rb.velocity.x, -SPEED_Y * 1.1f);
        }

        foreach (var raycast in raycasts)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycast.transform.position, -Vector2.up, 0.1f);

            if (hit)
                canJump = true;

            Debug.DrawRay(raycast.transform.position, -Vector2.up * 0.1f, Color.red);
        }
    }

    void ShipMovement()
    {
        
    }

    void MoveHorizontally(float speed)
        => rb.velocity = new Vector2(speed, rb.velocity.y);

    void TogglePlayerState()
    {
        var nextPlayerState = playerState == PlayerState.Cube ? PlayerState.Ship : PlayerState.Cube;
        
        if (nextPlayerState == PlayerState.Cube)
        {
            SwitchToCube();
        }
        else
        {
            SwitchToShip();
        }
    }

    void SwitchToCube()
    {
        playerState = PlayerState.Cube;
        Debug.Log("Switched to cube");
    }

    void SwitchToShip()
    {
        playerState = PlayerState.Ship;
        Debug.Log("Switched to ship");
    }
}
