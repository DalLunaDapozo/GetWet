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

    [SerializeField] private float speedMultiplierWhenPunk;

    private float punkSpeed;
    private float chillSpeed;
    private float speedlimit;

    [SerializeField] private GameController gameController;

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
    
        punkSpeed = movementSpeed_horizontal * speedMultiplierWhenPunk;
        chillSpeed = movementSpeed_horizontal;
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
        if (AudioManager.instance.mood == Mood.chill || AudioManager.instance.mood == Mood.none)
        {
            speedlimit = chillspeedlimit;
            movementSpeed_horizontal = chillSpeed;
        }
        else if (AudioManager.instance.mood == Mood.punk)
        {
            speedlimit = happyspeedlimit;
            movementSpeed_horizontal = punkSpeed;
        }
    }
    
    void StopMovement()
    {
        movementSpeed_horizontal = Mathf.Lerp(movementSpeed_horizontal, 0f, .1f);
        isRunning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            gameController.ShowEnding();
        }
    }


}
