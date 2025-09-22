using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.y, jumpForce);
            isGrounded = false; // Prevent double jumping
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is grounded when colliding with ground or platform
            Debug.Log("Player is grounded");
        }
    }

    //

    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 0.3f); // Bounce the player up slightly
    //        Destroy(gameObject); // Destroy player
    //        GameManager gameManager = FindAnyObjectByType<GameManager>();
    //        gameManager.GameOver(); // Trigger game over in GameManager
    //        Debug.Log("Player hit enemy and game over");
    //    }

    //    if (collision.gameObject.CompareTag("MovingObject"))
    //    {
    //        isGrounded = true;
    //        transform.SetParent(collision.transform); // Make the player a child of the moving object
    //        Debug.Log("Player is grounded on moving object");
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("MovingObject"))
    //    {
    //        isGrounded = true;
    //        transform.SetParent(null); // Remove the player from being a child of the object
    //        Debug.Log("Player exited moving object");
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Coins"))
    //    {
    //        Debug.Log("+1 coin");
    //        Destroy(collision.gameObject); // Destroy collectible
    //        GameManager gameManager = FindAnyObjectByType<GameManager>();
    //        gameManager.AddScore(1); // Add score in GameManager
    //    }

    //    if (collision.gameObject.CompareTag("HitBox"))
    //    {
    //        EnemyControl enemy = collision.GetComponentInParent<EnemyControl>();
    //        if (enemy != null)
    //        {
    //            enemy.Die(); // Call the Die method on the enemy                
    //        }
    //        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 0.5f); // Bounce the player up slightly
    //        Destroy(collision.gameObject); // Destroy the hitbox to prevent multiple triggers
    //        Debug.Log("Enemy hitbox triggered, enemy should die");
    //    }

    //}
}
