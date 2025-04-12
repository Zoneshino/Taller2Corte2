using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public float fallLimitY = -10f;
    private Vector2 lastSafePosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastSafePosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            if (LifeSystem.instance != null)
            {
                LifeSystem.instance.TakeDamage();
            }

            transform.position = lastSafePosition;
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            lastSafePosition = transform.position;
        }
    }
}