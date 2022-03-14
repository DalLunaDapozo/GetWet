using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Rigidbody rb;
    private PlayerControls inputActions;
    private Animator anim;

    
    [HideInInspector] public Vector2 inputVector;
    [HideInInspector] public bool isRunning;
   
    public bool canMove;

    [SerializeField] private float movementSpeed_horizontal;
    [SerializeField] private float movementSpeed_vertical;
   
    [SerializeField] private float chillspeedlimit;
    [SerializeField] private float happyspeedlimit;

    private float happySpeed;
    private float chillSpeed;
    private float speedlimit;

    private void Awake()
    {

        instance = this;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        inputActions = new PlayerControls();
        inputActions.Movement.Enable();

    }

    private void Start()
    {
        canMove = true;
        happySpeed = movementSpeed_horizontal;
        chillSpeed = movementSpeed_horizontal / 1.2f;
    }

    private void Update()
    {
        ReadVector2Value(ref inputVector);
        CheckMusicMood();
    }

    private void FixedUpdate()
    {
        AddForceMovement();
    }

    private void ReadVector2Value(ref Vector2 value)
    {
        if (canMove)
            value = inputActions.Movement.Move.ReadValue<Vector2>();
    }

    private void AddForceMovement()
    {
        if (rb.velocity.z < speedlimit && rb.velocity.z > -speedlimit)
        {
            rb.AddForce(new Vector3(-inputVector.y * movementSpeed_vertical * Time.deltaTime, 0f, inputVector.x * movementSpeed_horizontal * Time.deltaTime), ForceMode.Acceleration);
        }
    }
    
    public bool CheckIfMoving()
    {
        if (rb.velocity != Vector3.zero)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void CheckMusicMood()
    {
        if (AudioManager.instance.mood == Mood.chill)
        {
            speedlimit = chillspeedlimit;
            movementSpeed_horizontal = chillSpeed;
        }
        else if (AudioManager.instance.mood == Mood.happy)
        {
            speedlimit = happyspeedlimit;
            movementSpeed_horizontal = happySpeed;
        }
    }
    
    void StopMovement()
    {
        movementSpeed_horizontal = Mathf.Lerp(movementSpeed_horizontal, 0f, .1f);
        isRunning = false;
    }

}
