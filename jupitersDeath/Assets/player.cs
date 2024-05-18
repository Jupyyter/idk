using UnityEngine;

public class player : MonoBehaviour
{
    private char xb;
    private char yb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.xb = ' ';
        this.yb = ' ';
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D) && (xb == 'D' || xb == ' '))
        {
            xb = 'D';
            this.transform.position += new Vector3(0.01f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) && (xb == 'A' || xb == ' '))
        {
            xb = 'A';
            this.transform.position -= new Vector3(0.01f, 0, 0);
        }
        else{
            xb = ' ';
        }
        
        if (Input.GetKey(KeyCode.W) && (yb == 'W' || yb == ' '))
        {
            yb = 'W';
            this.transform.position += new Vector3(0, 0.01f, 0);
        }
        else if (Input.GetKey(KeyCode.S) && (yb == 'S' || yb == ' '))
        {
            yb = 'S';
            this.transform.position -= new Vector3(0, 0.01f, 0);
        }
        else{
            yb = ' ';
        }
        
        if(yb == 'W'){
            if(xb == ' '){
                this.GetComponent<Animator>().Play("mageMoveUp");
            }
            else{
                this.GetComponent<Animator>().Play("mageMoveUpRight");
            }
        }
        else if(xb == ' '){
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

    }
}
