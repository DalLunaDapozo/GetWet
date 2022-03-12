using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerMovement movement;
    private Vector3 spriteScale;

    private Animator anim;

    private void Awake()
    {
        movement = GetComponentInParent<PlayerMovement>();
        anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        spriteScale = transform.localScale;
    }

    private void Update()
    {
        RotateSprite();
        anim.SetBool("Moving", movement.CheckIfMoving());
        
    }

    private void RotateSprite()
    {
        if (movement.inputVector.x < 0)
            GameObject.Find("Sprite").transform.localScale = new Vector3(-spriteScale.x, spriteScale.y, spriteScale.z);
        else if (movement.inputVector.x > 0)
            GameObject.Find("Sprite").transform.localScale = new Vector3(spriteScale.x, spriteScale.y, spriteScale.z);
    }
}
