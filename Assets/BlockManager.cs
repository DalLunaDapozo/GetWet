using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private float[] blockpositions;
    [SerializeField] private GameObject[] blocks;

    [SerializeField] private Transform player;

    [SerializeField] private float distanceToRender;

    private void Awake()
    {

        for (int i = 0; i < blocks.Length; i++)
        {
            blockpositions[i] = blocks[i].transform.position.z;
            blocks[i].SetActive(false);      
        }
    }

    private void Update()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (distanceToRender > Vector3.Distance(blocks[i].transform.position, player.position))
            {
                blocks[i].SetActive(true);
            }
            else
            {
                blocks[i].SetActive(false);
            }
        }
    }
}
