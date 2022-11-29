using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveVector;
    //Reference
    public CharacterController ch_controller;
    private Animator ch_animator;
    //Jump logic
    [Header("Gravity & Jumping")]
    public float stickToGroundForce = 10;
    public float gravity = 10;
    public float jumpForce = 10;

   

    private float verticalVelocity;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayers;
    public float groundCheckRadius;

    

    

    private bool grounded;

    private MobileController mController;
    //private Transform camTransform;

    //stopping player movement when having dialogues
    public bool canMove;



    // Start is called before the first frame update
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        mController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
        canMove = true;
        
    }

   
    void Update()
    {

        
        CharacterMove();
        //CharacterMove();

        //-Rotate our moveVector
       // moveVector = RotateWithView();

        if(!canMove)
        {
            
            moveSpeed = 0;
            return;
        }
        else
        {
            moveSpeed = 2;
            return;
        }
        
        
    
    }

    public void Attack()
    {
        if (!ch_animator.GetBool("Move"))
        {
            ch_animator.SetTrigger("Attack");
        }
    }
     public void Run()
    {
         if (!ch_animator.GetBool("Move"))
        {
            ch_animator.SetTrigger("Special");
        }
    }

    public void Jump()
    {
        if (grounded) verticalVelocity = jumpForce;
        
       
      
       
    }

    

    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = mController.Horizontal() * moveSpeed;
        moveVector.z = mController.Vertical() * moveSpeed;

       

        //float inputX = mController.Horizontal();
        //float inputY = mController.Vertical();
        
        

    

    
        if (grounded && verticalVelocity <= 0) verticalVelocity = -stickToGroundForce * Time.deltaTime;
        
           
        
    
        else verticalVelocity -= gravity * Time.deltaTime;

       if (!grounded)
        {
            ch_animator.SetBool("Jump", true);
        } 
        else
        {
            ch_animator.SetBool("Jump", false);
        }
        

        //apply y vertical movement

        Vector3 verticalMovement = transform.up * verticalVelocity;
        ch_controller.Move(verticalMovement * Time.deltaTime);

        if(moveVector.x != 0 || moveVector.z != 0)
        {
            
            ch_animator.SetBool("Move", true);
        }
        else
        {
            ch_animator.SetBool("Move", false);
        }

        if(Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        

        ch_controller.Move(moveVector * Time.deltaTime);
    }
    



    void FixedUpdate()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayers);
       
    }
}