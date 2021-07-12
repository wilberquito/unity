using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    int score = 0;
    Text textRef;

    [SerializeField] string scoreTextName = "scoreText";


    private void Awake()
    {
        var list = FindObjectsOfType<GameScore>();

        if (list.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        CacheScoreText(scoreTextName);
    }

    public void CacheScoreText(string text) {
        int i = 0;
        bool found = false;

        var references = FindObjectsOfType(typeof(Text), true);
        
        while(i < references.Length && !found) {
            if (references[i].name == text) {
                found = true;
                textRef = (Text) references[i];
            }
            i++;
        }

        if (!found) {
            Debug.LogError("Text not in game session");
        } else {
            textRef.gameObject.SetActive(true);
            UpdateScoreTextRef();
        }
    }

    public int ScoreUntilNow() {
        return this.score;
    }
    //inicializa el score y no muestra el layout
    public void ResetScore()
    {
        this.score = 0;
    }

    private void UpdateScoreTextRef() {

        if (textRef) {
            textRef.text = $"Score: {this.score}";
        }
    }

    // n >= 0
    public void IncreaseScore(int n)
    {
        score += n;
        UpdateScoreTextRef();
    }

}
