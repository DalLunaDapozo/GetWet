using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerMovement movement;
    private Vector3 spriteScale;

    private Animator anim;

    private GameObject trails;

    public static bool isRotated;

    private void Awake()
    {
        movement = GetComponentInParent<PlayerMovement>();
        anim = GetComponentInParent<Animator>();
        trails = GameObject.Find("Trails");
    }

    private void Start()
    {
        spriteScale = transform.localScale;
        isRotated = false;
    }

    private void Update()
    {
        RotateSprite();
        anim.SetBool("Moving", movement.CheckIfMoving());

        if (AudioManager.instance.mood == Mood.chill || AudioManager.instance.mood == Mood.none)
        {
            // trails.SetActive(false);
        }
        else if (AudioManager.instance.mood == Mood.punk)
        {
            Ghosts.me.Ghost_Skill(); 
            //trails.SetActive(true);
        }
    }

    private void RotateSprite()
    {
        if (movement.inputVector.x < 0)
        {
            isRotated = true;
            GameObject.Find("Sprite").transform.localScale = new Vector3(-spriteScale.x, spriteScale.y, spriteScale.z);
        }
        else if (movement.inputVector.x > 0)
        {
            isRotated = false;
            GameObject.Find("Sprite").transform.localScale = new Vector3(spriteScale.x, spriteScale.y, spriteScale.z);
        }
           
    }
}
