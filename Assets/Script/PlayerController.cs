
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float gravityScale = 3f;

    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();

        if (rb == null)
        {
            Debug.LogError("Player needs a Rigidbody2D!");
            enabled = false;
            return;
        }

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = gravityScale;
        rb.simulated = true;
    }

    void Update()
    {
        if (GameManager.gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        float angle = Mathf.Clamp(rb.linearVelocity.y * 5f, -25f, 25f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

   void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log(" برخورد با: " + collision.gameObject.name
        + " | Tag: " + collision.gameObject.tag);

    if (collision.gameObject.CompareTag("Pipe2") ||
        collision.gameObject.CompareTag("Ground"))
    {
        Debug.Log("GAME OVER!");

        if (gameManager != null)
            gameManager.GameOver();
        else
            Debug.LogError("GameManager پیدا نشد!");
    }
}
}
