using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solid : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader myMaterial;

    public GameObject player;

    private Vector3 spriteScale;

    [SerializeField] public Color _color;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myMaterial = Shader.Find("Universal Render Pipeline/2D/Sprite-Lit-Default");
        transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);

        spriteScale = transform.localScale;
    }

    private void OnEnable()
    {
        if (PlayerAnimations.isRotated == true)
        {
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
        }
        else if (PlayerAnimations.isRotated == false)
        {
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Update()
    {
        ColorSprite();

        

    }

    public void Finish()
    {
        gameObject.SetActive(false);
    }

    private void ColorSprite()
    {
        myRenderer.material.shader = myMaterial;
        myRenderer.color = _color;

       
    }
    
}
