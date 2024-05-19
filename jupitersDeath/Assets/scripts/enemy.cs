using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from the enemy to the player
        rb.velocity = playerTransform.position - transform.position;
        // Normalize the direction to get a unit vector
        rb.velocity = rb.velocity.normalized * moveSpeed;

    }
}
