using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneController.LoadScene("Test", 1f ,1f );
    }

    public void Quit()
    {
        Application.Quit();
    }
}
