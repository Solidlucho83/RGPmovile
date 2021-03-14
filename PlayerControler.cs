using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using UnityEngine;


public class PlayerControler : MonoBehaviour
{

    public float speed = 4.0f;
    private float currentSpeed;

    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastVertical = "LastVertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";


    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playercolor;
    public static bool playerCreated;
    public static bool cameraCreated;

    public string nextPlaceName;


    private bool attacking = false;
    public float attackTime;
    private float attackTimeCounter;

    public bool playerTalking;


    private SFXSoundManager SFXSoundManager;


   /* void Awake()
    {


        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
      /*  if (!cameraCreated)
        {
            cameraCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update*/

    void Start()
    {
     /*   if (!cameraCreated)
        {
            cameraCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            cameraCreated = false;
        }*/

        SFXSoundManager = FindObjectOfType<SFXSoundManager>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playercolor = GetComponent<SpriteRenderer>();

    }


    ///Google Admob


    void Update()
        {
            walking = false;
            if (/*Input.GetMouseButtonDown(0) ||*/ Input.GetButtonDown("Fire1"))

            {
                attacking = true;
                attackTimeCounter = attackTime;
                playerRigidbody.velocity = Vector2.zero;

                animator.SetBool(attackingState, true);
                SFXSoundManager.espada.Play();
            }

            if (attacking)
            {
                attackTimeCounter -= Time.deltaTime;
                if (attackTimeCounter < 0)
                {
                    attacking = false;
                    animator.SetBool(attackingState, false);
                }
            }
        }
        void FixedUpdate()
        {
            if (playerTalking)
            {
                playerRigidbody.velocity = Vector2.zero;
                return;
            }



            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.1f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.1f)
            {

                //Ultima posicion de movimiento.
                walking = true;

                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));

                //Calculamos la posicion de movimiento y la normalizamos.
                playerRigidbody.velocity = lastMovement.normalized * speed * Time.deltaTime;

            }




            if (!walking)
            {
                playerRigidbody.velocity = Vector2.zero;

            }

            animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
            animator.SetFloat(vertical, Input.GetAxisRaw(vertical));


            animator.SetBool(walkingState, walking);


            animator.SetFloat(lastHorizontal, lastMovement.x);
            animator.SetFloat(lastVertical, lastMovement.y);
        }
    }

    
   

 
 

