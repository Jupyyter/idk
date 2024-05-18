using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform firePoint;
    private string currentState;
    private Animator anim;
    private float dirx;
    private float diry;
    private const string MAGE_MOVE_UP = "mageMoveUp";
    private const string MAGE_MOVE_UP_RIGHT = "mageMoveUpRight";
    private const string MAGE_MOVE_DOWN = "mageIdle";
    private const string MAGE_MOVE_RIGHT = "mageMoveRight";
    private const string MAGE_WEAPON = "mageWeapon";
    private const string MAGE_WEAPON_UNUSED = "mageWeaponUnused";
    [SerializeField] private GameObject projectile;
    private Rigidbody2D rb;
    private Vector2 lastDirection;
    private const int MOVE_SPEED = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weapon.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 0);
        dirx = Input.GetAxisRaw("Horizontal");
        diry = Input.GetAxisRaw("Vertical");
        lastDirection=new Vector2(dirx * MOVE_SPEED, diry * MOVE_SPEED);
        rb.velocity = lastDirection;//move
        animate(rb.velocity);


        if (Input.GetKey(KeyCode.Z))
        {
            weapon.SetActive(true);
            shoot(firePoint.position,transform.rotation);
        }
        

    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void animate(Vector2 velocity){
        if (velocity != Vector2.zero)
        {
            if (dirx > 0)
            {
                this.transform.rotation = new Quaternion(0,0,0,0);
            }
            else
            {
                this.transform.rotation = new Quaternion(0,180,0,0);
            }
            if (diry > 0)
            {
                if(dirx==0){
                    changeAnimationState(MAGE_MOVE_UP);
                }
                else{
                    changeAnimationState(MAGE_MOVE_UP_RIGHT);
                }
            }
            else
            {
                if(dirx==0){
                    changeAnimationState(MAGE_MOVE_DOWN);
                }
                else{
                    changeAnimationState(MAGE_MOVE_RIGHT);
                }
            }

        }
    }

    private void changeAnimationState(string newState)
    {
        if (currentState == newState) return;//if the same animation plays
        anim.Play(newState);
        currentState = newState;
    }
    private void shoot(Vector3 pos, Quaternion quar)//spawns bullets at fire points with their coordinates and random degrees 1 hand at time
    {
        Quaternion rotationn = Quaternion.Euler(0, 0, Random.Range(-3, 3));
        rotationn *= quar;
        GameObject bulletClone = Instantiate(projectile, pos, rotationn);
    }
    private void attackEnd(){
        if (!Input.GetKey(KeyCode.Z)){
            weapon.SetActive(false);
        }
    }
}
