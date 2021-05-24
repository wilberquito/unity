using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// para poder gestionar las scene
// se necesita el siguiente import UnityEngine.SceneManagert
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static void LoadNextScene()
    {

        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIdx == 3)
        {
            currentSceneIdx = -1;
        }

        int nextScene = currentSceneIdx + 1;

        if (nextScene == 0)
        {
            PurgeGameStatus();
        }

        SceneManager.LoadScene(nextScene);
    }

    public static void PurgeGameStatus()
    {
        GameSession gs = FindObjectOfType<GameSession>();

        if (gs != null)
        {
            Debug.Log("Killing game status process...");
            gs.PurgeGameStatus();
        }


    }

    public void QuickGame()
    {
        Application.Quit();
    }
}
