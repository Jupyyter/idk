using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<fireballScript>() != null){
            Destroy(gameObject);
        }
    }

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
        if (rb.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }

        if (rb.velocity.magnitude <= 1)
        {
            rb.velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().Play("monsterAttack");
        }
        else
        {
            // Normalize the direction to get a unit vector
            rb.velocity = rb.velocity.normalized * moveSpeed;
            GetComponent<Animator>().Play("monsterWalk");
        }
    }
}
