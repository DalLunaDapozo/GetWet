using UnityEngine.Playables;
using UnityEngine;

public class TimelinePlayer : MonoBehaviour
{
    private PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    void Director_Played(PlayableDirector obj)
    {
        
    }

    void Director_Stopped(PlayableDirector obj)
    {
        SceneController.LoadScene("Test", 1f, 1f);
    }

    public void StartTimeline()
    {
        director.Play();
    }
}
