using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePickUpsAppear : MonoBehaviour
{

    [SerializeField] private GameObject objects;
    
    void Update()
    {
        if (AudioManager.instance.mood == Mood.chill || AudioManager.instance.mood == Mood.none)
        {
            objects.SetActive(false);
        }
        else if (AudioManager.instance.mood == Mood.punk)
        {
            objects.SetActive(true);
        }
    }
}
