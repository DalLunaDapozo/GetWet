using UnityEngine;

public class PickUp : MonoBehaviour
{
    private BoxCollider boxCollider;
    [SerializeField] private ParticleSystem poof;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.scoreValue++;
            Instantiate(poof, transform.position, Quaternion.identity);
            AudioManager.instance.Play("Beep");
            Destroy(gameObject);
        }
    }
 
}
