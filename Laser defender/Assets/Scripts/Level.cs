using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private void RemoveObjects() {
        // borramos el game score object
        var arrayOfObjects = FindObjectsOfType<GameScore>();
        var listOfObjects = new List<GameScore>(arrayOfObjects);

        foreach(var ob in listOfObjects) {
            Destroy(ob.gameObject);
        }
    }

    public void LoadStarMenu()
    {
        if (SceneMayExist(startMenuSceneIdx))
        {
            // removing objects that they dont need to exist enymore
            RemoveObjects();
            SceneManager.LoadScene(startMenuSceneIdx);
        }
        else
        {
            Debug.LogError("La escena de menu no existe!");
        }
    }

    public void LoadGameScene()
    {
        if (SceneMayExist(gameSceneIdx))
        {
            SceneManager.LoadScene(gameSceneIdx);
        }
        else
        {
            Debug.LogError("La escena de game no existe!");
        }
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

    private IEnumerator CoroutineGameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(gameOverSceneIdx);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}
