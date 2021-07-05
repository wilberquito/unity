using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    TextMeshProUGUI text;
    [SerializeField] string textMeshName = "ScoreText";

    private void Awake()
    {
        var list = FindObjectsOfType<GameSession>();

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
        CacheScoreText();
        UpdateScoreRender();
    }

    private void CacheScoreText() {
        int i = 0;
        bool found = false;

        var references = FindObjectsOfType(typeof(TextMeshProUGUI), true);
        
        while(i < references.Length && !found) {
            if (references[i].name == textMeshName) {
                found = true;
                text = (TextMeshProUGUI) references[i];
            }
            i++;
        }

        if (!found) {
            Debug.LogError("Text not in game session");
        }
    }

    //inicializa el score y no muestra el layout
    public void ResetScore()
    {
        text.gameObject.SetActive(false);
        //reseting score
        this.score = 0;
    }

    public void ShowScore() {
        text.gameObject.SetActive(true);
    }

    // n >= 0
    public void IncreaseScore(int n)
    {
        score += n;
        UpdateScoreRender();
    }

    private void UpdateScoreRender() {
        text.text = $"Score: {score}";
    }
}
