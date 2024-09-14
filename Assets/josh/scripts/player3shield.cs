using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class player3shield : MonoBehaviour
{
    public GameObject Player;
    private BoxCollider2D bc;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void ChangeTransparency(float alpha)
    {
        // Clamp alpha value between 0 (fully transparent) and 1 (fully opaque)
        alpha = Mathf.Clamp01(alpha);

        // Get the current color
        Color color = spriteRenderer.color;

        // Set the new alpha value
        color.a = alpha;

        // Apply the new color with updated alpha
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (player3.invincible == true )
        {
            spriteRenderer.color = new Color(0.5f, 0f, 0.5f);
            ChangeTransparency(0.6f);
        }
        if (player3.invincible == false )
        {
            spriteRenderer.color = Color.blue;
            ChangeTransparency(0.6f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("wall") && !collision.gameObject.CompareTag("ground") && collision.gameObject != player3.pl3)
        {
            Destroy(collision.gameObject);
            player3.shieldmax++;
            player3.shield = player3.shieldmax;
        }
    }
}
