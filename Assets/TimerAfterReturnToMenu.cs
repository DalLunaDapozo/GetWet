using UnityEngine;
using System.Collections;

public class TimerAfterReturnToMenu : MonoBehaviour
{

    float timer;

    private void Start()
    {

        timer = 4f;

        StartCoroutine(StartTimer());
    
    }

    IEnumerator StartTimer()
    {

        Debug.Log(timer);

        yield return new WaitForSeconds(timer);

        SceneController.LoadScene("Menu", 1f, 1f);

    }

    private void OnDestroy()
    {
        PlayerPrefs.DeleteKey("points");
    }
}
