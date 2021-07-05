using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{

    private int startMenuSceneIdx = 0;
    private int gameSceneIdx = 1;
    private int gameOverSceneIdx = 2;

    private bool SceneMayExist(int idx)
    {
        //none scene added in buiild settings
        if (SceneManager.sceneCountInBuildSettings < 0)
        {
            return false;
        }
        else
        {
            return idx >= 0 && idx < SceneManager.sceneCountInBuildSettings;
        }
    }

    public void LoadStarMenu()
    {
        if (SceneMayExist(startMenuSceneIdx))
        {
            SceneManager.LoadScene(startMenuSceneIdx);
            var gameSession = FindObjectOfType<GameSession>();
            gameSession.ResetScore();
        }
        else
        {
            Debug.LogError("La escena de menu no existe!");
        }
    }

    public void LoadGameScene()
    {
        Debug.Log("loading game scene");
        if (SceneMayExist(gameSceneIdx))
        {
            SceneManager.LoadScene(gameSceneIdx);
            var gameSession = FindObjectOfType<GameSession>();
            gameSession.ShowScore();
        }
        else
        {
            Debug.LogError("La escena de game no existe!");
        }
    }

    private IEnumerator CoroutineGameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(gameOverSceneIdx);
    }

    public void LoadGameOver()
    {
        if (SceneMayExist(gameOverSceneIdx))
        {
            StartCoroutine(CoroutineGameOver());
        }
        else
        {
            Debug.LogError("La escena de game over no existe!");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
