using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// para poder gestionar las scene
// se necesita el siguiente import UnityEngine.SceneManagert
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void LoadNextScene()
    {

        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIdx == 2)
        {
            currentSceneIdx = -1;
        }

        SceneManager.LoadScene(currentSceneIdx + 1);
    }
}
