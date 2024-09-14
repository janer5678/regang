using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explosionSize;
    [SerializeField] private float explosionRate;

    private Rigidbody2D _rb;

    private bool _isExploding;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rb is null) return;

        _rb.constraints = RigidbodyConstraints2D.FreezePosition;

        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
        }

        if (!_isExploding)
        {
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        _isExploding = true;

        // assume scale.x and scale.y are always equal
        while (transform.localScale.x < explosionSize)
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y) + Vector2.one * explosionRate;
            yield return new WaitForSeconds(0.02f);
        }

        Destroy(gameObject);
    }
}
