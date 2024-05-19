using UnityEngine;

public class fireballScript : MonoBehaviour
{
    
    private float speed = 19;
    private float secondsToLive = 1;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<player>() == null)
            Destroy(gameObject);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        if (!GetComponent<Renderer>().isVisible)//if the bullet is not on the screen....
        {
            secondsToLive -= Time.deltaTime;
            if (secondsToLive < 0)//and 1 second passes....
            {
                Destroy(gameObject);//IT DIES ☠️:):):):)
            }
        }
    }
}
