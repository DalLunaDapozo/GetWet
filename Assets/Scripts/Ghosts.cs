using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public static Ghosts me;
    public GameObject _ghost;
    public List<GameObject> pool = new List<GameObject>();
    private float timer;
    public float speed;
    public Color _color;

    public float posCorrection;

    private void Awake()
    {
        me = this;
    }

    public GameObject GetGhosts()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                
                pool[i].SetActive(true);
                pool[i].transform.position = new Vector3(transform.position.x + posCorrection, transform.position.y, transform.position.z);
                pool[i].transform.rotation = transform.rotation;
             
                pool[i].GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;

                

                return pool[i];
            }
        }
        GameObject obj = Instantiate(_ghost, new Vector3(transform.position.x + posCorrection, transform.position.y, transform.position.z), transform.rotation);
        
        obj.GetComponent< SpriteRenderer > ().sprite = GetComponent<SpriteRenderer>().sprite;
        
        pool.Add(obj);
        return obj;
    }
    
    public void Ghost_Skill()
    {
        timer += speed * Time.deltaTime;
        if (timer > 1f)
        {
            GetGhosts();
            timer = 0;
        }
    }
}
