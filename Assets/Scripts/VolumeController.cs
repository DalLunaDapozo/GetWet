using UnityEngine.Rendering;
using UnityEngine;

public class VolumeController : MonoBehaviour
{

    private Volume vol;
    [SerializeField] private BoxCollider boxcollider;

    private void Awake()
    {
        vol = GetComponent<Volume>();
        boxcollider = GetComponent<BoxCollider>();
        boxcollider.enabled = false;
    }

    void Update()
    {
        
        if (AudioManager.instance.mood == Mood.chill || AudioManager.instance.mood == Mood.none)
        {
            boxcollider.enabled = false;
        }
        else if (AudioManager.instance.mood == Mood.punk)
        {
            boxcollider.enabled = true;
        }
    }
}
