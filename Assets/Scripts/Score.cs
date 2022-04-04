using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

  
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public static int scoreValue = 0;

    public string pointsPref;

    private void Awake()
    {

        pointsPref = "points";
        if (PlayerPrefs.HasKey(pointsPref))
        {
            scoreValue = PlayerPrefs.GetInt(pointsPref, 0);
        }
        else
        {
            scoreValue = 0;
            PlayerPrefs.SetInt(pointsPref, 0);
        }
    }

    void Start()
    {
        scoreText.text = "Score: 0";
        scoreText.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (AudioManager.instance.mood == Mood.chill || AudioManager.instance.mood == Mood.none)
        {
            scoreText.gameObject.SetActive(false);
        
        }
        else if (AudioManager.instance.mood == Mood.punk)
        {
            
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Score: " + scoreValue;

        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(pointsPref, Score.scoreValue);
    }


}
