using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    //Load the Level One Scene
    public void LoadLevelOneScene()
    {
        StartCoroutine(LoadScene("Level One"));
    }

    /// <summary>
    /// Load any scene through async
    /// </summary>
    /// <param name="sceneName">The name of the scene</param>
    /// <returns></returns>
    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);

        while (!loadingScene.isDone)
        {
            yield return null;
        }
    }
}
