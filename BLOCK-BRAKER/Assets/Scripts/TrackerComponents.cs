using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerComponents : MonoBehaviour
{
    [SerializeField] int nBlocks = 0;

    GameSession gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }

    public void AddBlock()
    {
        nBlocks += 1;
    }

    public void SubstractBlock()
    {
        nBlocks -= 1;

        if (nBlocks == 0)
        {
            SceneLoader.LoadNextScene();
        }

        UpdateScore(gameStatus.PointsPerBlockDestroyed());
    }

    private void UpdateScore(int points)
    {
        gameStatus.UpdateScore(points);
    }
}
