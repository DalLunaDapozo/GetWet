using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{

    private PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Movement.Enable();

        inputActions.Movement.ChangeMusic.performed += ChangeMusic;
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic("Lofi_prueba");
        //AudioManager.instance.Play("Rain_1");
    }


    private void ChangeMusic(InputAction.CallbackContext context) 
    {
        AudioManager.instance.StartCoroutine("SwitchMusic");
    }
}
