using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSession : MonoBehaviour
{

    [Range(0.1f, 2f)] [SerializeField] float gameVelocity = 0.5f;

    [SerializeField] int score = 0;

    [SerializeField] int pointsPerBlock = 100;

    [SerializeField] TextMeshProUGUI scoreText;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        // patron singleton. Borra la nueva instancia y mantiene la anterior
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // esta funci�n mata el singleton
    public void PurgeGameStatus()
    {
        Destroy(gameObject);
    }


    public int PointsPerBlockDestroyed()
    {
        return pointsPerBlock;
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = $"Score: {score} points";
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = gameVelocity;
        scoreText.text = $"Score: {score} points";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
