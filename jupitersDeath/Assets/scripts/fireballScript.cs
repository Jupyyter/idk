using UnityEngine;

public class fireballScript : MonoBehaviour
{
    
    private float speed = 37;
    private float number = 1;
    private Rigidbody2D rb;
    [SerializeField] private GameObject happyend;
    private BoxCollider2D BX;
    [SerializeField] Transform truTransform;
    [SerializeField] Transform d2;
    [SerializeField] Transform d3;
    private void Start()
    {
        BX = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        if (!GetComponent<Renderer>().isVisible)//if the bullet is not on the screen....
        {
            number -= Time.deltaTime;
            if (number < 0)//and 1 second passes....
            {
                Destroy(gameObject);//IT DIES ☠️:):):):)
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
    }
    private void CmdendBullet()
    {
        GameObject happyendPref = Instantiate(happyend, truTransform.position, transform.rotation);
    }
}
