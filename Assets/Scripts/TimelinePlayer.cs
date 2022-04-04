using UnityEngine.Playables;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TimelinePlayer : MonoBehaviour
{
    private PlayableDirector director;

    [SerializeField] private TextMeshProUGUI canSkipSceneText;

    private bool isActive;

    private PlayerControls inputActions;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;

        inputActions = new PlayerControls();
        inputActions.Movement.Enable();

        inputActions.Movement.SkipScene.performed += SkipScene;
    }

    private void OnDestroy()
    {
        inputActions.Movement.SkipScene.performed -= SkipScene;
    }

    private void Start()
    {
        canSkipSceneText.gameObject.SetActive(false);
        isActive = false;
    }

 
    void Director_Played(PlayableDirector obj)
    {
        
    }

    void Director_Stopped(PlayableDirector obj)
    {
        SceneController.LoadScene("Gameplay", 1f, 1f);
    }

    public void StartTimeline()
    {
        director.Play();
        canSkipSceneText.gameObject.SetActive(true);
        isActive = true;
    }

    private void SkipScene(InputAction.CallbackContext context)
    {
        director.stopped -= Director_Stopped;
        SceneController.LoadScene("Gameplay", 1f, 1f);
    }
    
}
