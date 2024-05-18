using UnityEngine;

public class batscript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(this.transform.rotation.eulerAngles.y == 180){
            rb.velocity = new Vector3(-10.0f, 0, 0);
        }
        else{
            rb.velocity = new Vector3(10.0f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
