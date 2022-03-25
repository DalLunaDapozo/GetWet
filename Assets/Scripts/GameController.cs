using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;

public enum Mood { chill, punk, none, cagarEnElBidet }

public class GameController : MonoBehaviour
{
    private float[] timeElapsedInEachMood;
    private PlayerControls inputActions;

    public Mood mood = Mood.chill;

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Movement.Enable();

        inputActions.Movement.ChangeMusic.performed += ChangeMusic;
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic("Lofi_prueba");
        timeElapsedInEachMood = new float[4];
        //AudioManager.instance.Play("Rain_1");
    }

    private void Update()
    {
        timeElapsedInEachMood[(int)AudioManager.instance.mood] += Time.deltaTime;
    }

    private void ChangeMusic(InputAction.CallbackContext context) 
    {
        AudioManager.instance.StartCoroutine("SwitchMusic");
    }

    public void ShowEnding()
    {
        float playTime = timeElapsedInEachMood.Sum();

        if (timeElapsedInEachMood[0] > playTime / 2)
            Debug.Log("Final Chill");
        else
            Debug.Log("Final Punk");

    }

}
