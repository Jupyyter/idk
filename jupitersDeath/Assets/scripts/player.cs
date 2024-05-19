using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform firePoint;
    private string currentState;
    private Animator anim;
    private const string MAGE_MOVE_UP = "mageMoveUp";
    private const string MAGE_MOVE_UP_RIGHT = "mageMoveUpRight";
    private const string MAGE_MOVE_DOWN = "mageIdle";
    private const string MAGE_MOVE_RIGHT = "mageMoveRight";
    private const string MAGE_WEAPON = "mageWeapon";
    private const string MAGE_WEAPON_UNUSED = "mageWeaponUnused";
    [SerializeField] private GameObject projectile;
    private Rigidbody2D rb;
    private const int MOVE_SPEED = 3;
    private bool canshoot = true;
    private float counter = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
    }

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
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        rb.velocity = rb.velocity.normalized * MOVE_SPEED;
        animate();

        if (!canshoot)
        {
            counter += Time.deltaTime;
            if (counter > 0.10f)
            {//limiting shooting to once 0.10 seconds from god mode
                canshoot = true;
                counter = 0;
            }
        }

        if (Input.GetKey(KeyCode.Z)&&canshoot)
        {
            weapon.SetActive(true);
            shoot(firePoint.position, firePoint.rotation);
            canshoot=false;
        }


    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void animate()
    {
        if (rb.velocity != Vector2.zero)
        {
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                firePoint.localPosition = new Vector3(1, 0, 0);
                firePoint.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                firePoint.localPosition = new Vector3(1, 0, 0);
                firePoint.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (rb.velocity.y > 0)
            {
                if (rb.velocity.x == 0)
                {
                    changeAnimationState(MAGE_MOVE_UP);
                    firePoint.localPosition = new Vector3(0, 0.5f, 0);
                    firePoint.rotation = Quaternion.Euler(0, 0, 90);
                }
                else
                {
                    changeAnimationState(MAGE_MOVE_UP_RIGHT);
                    if (rb.velocity.x > 0)
                    {
                        firePoint.localPosition = new Vector3(0.5f, 0.5f, 0);
                        firePoint.rotation = Quaternion.Euler(0, 0, 45);
                    }
                    else
                    {
                        firePoint.localPosition = new Vector3(0.5f, 0.5f, 0);
                        firePoint.rotation = Quaternion.Euler(0, 0, 135);
                    }
                }
            }
            else
            {
                if (rb.velocity.x == 0)
                {
                    changeAnimationState(MAGE_MOVE_DOWN);
                    firePoint.localPosition = new Vector3(0, -0.5f, 0);
                    firePoint.rotation = Quaternion.Euler(0, 0, -90);
                }
                else
                {
                    changeAnimationState(MAGE_MOVE_RIGHT);
                    if (rb.velocity.y != 0)
                    {
                        if (rb.velocity.x > 0)
                        {
                            firePoint.localPosition = new Vector3(0.5f, -0.5f, 0);
                            firePoint.rotation = Quaternion.Euler(0, 0, -45);
                        }
                        else
                        {
                            firePoint.localPosition = new Vector3(0.5f, -0.5f, 0);
                            firePoint.rotation = Quaternion.Euler(0, 0, -135);
                        }
                    }
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
    private void shoot(Vector2 pos, Quaternion quar)//spawns bullets at fire points with their coordinates and random degrees 1 hand at time
    {
        Quaternion rotationn = Quaternion.Euler(0, 0, Random.Range(-3, 3));
        rotationn *= quar;
        GameObject bulletClone = Instantiate(projectile, pos, rotationn);
    }
    private void attackEnd()
    {
        if (!Input.GetKey(KeyCode.Z))
        {
            weapon.SetActive(false);
        }
    }
}
