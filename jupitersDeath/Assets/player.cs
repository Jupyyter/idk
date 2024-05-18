using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private GameObject BatPrefab;
    private Rigidbody2D rb;
    private char xb;
    private char yb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.xb = ' ';
        this.yb = ' ';
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.D) && (xb == 'D' || xb == ' '))
        {
            xb = 'D';
            rb.velocity = new Vector3(1.0f, rb.velocity.y, 0);
        }
        else if (Input.GetKey(KeyCode.A) && (xb == 'A' || xb == ' '))
        {
            xb = 'A';
            rb.velocity = new Vector3(-1.0f, rb.velocity.y, 0);
        }
        else{
            xb = ' ';
        }
        
        if (Input.GetKey(KeyCode.W) && (yb == 'W' || yb == ' '))
        {
            yb = 'W';
            rb.velocity = new Vector3(rb.velocity.x, 1.0f, 0);
        }
        else if (Input.GetKey(KeyCode.S) && (yb == 'S' || yb == ' '))
        {
            yb = 'S';
            rb.velocity = new Vector3(rb.velocity.x, -1.0f, 0);
        }
        else{
            yb = ' ';
        }

        rb.velocity = rb.velocity.normalized * 3;
        
        if(yb == 'W'){
            if(xb == ' '){
                this.GetComponent<Animator>().Play("mageMoveUp");
            }
            else{
                this.GetComponent<Animator>().Play("mageMoveUpRight");
            }
        }
        else if(xb == ' ' && yb == 'S'){
            this.transform.localScale = new Vector3(1, 1, 1);
            this.GetComponent<Animator>().Play("mageIdle");
        }

        if(xb == 'A'){
            this.transform.localScale = new Vector3(-1, 1, 1);
            if(yb != 'W'){
                this.GetComponent<Animator>().Play("mageMoveRight");
            }
        }
        else if(xb == 'D'){
            this.transform.localScale = new Vector3(1, 1, 1);
            if(yb != 'W'){
                this.GetComponent<Animator>().Play("mageMoveRight");
            }
        }
        if(Input.GetKey(KeyCode.E)){
            if(this.transform.localScale.x > 0){
                Instantiate(BatPrefab, this.transform.position, Quaternion.identity);
            }
            else{
                Instantiate(BatPrefab, this.transform.position,Quaternion.Euler(0, 180, 0));
            }
        }

    }
}
