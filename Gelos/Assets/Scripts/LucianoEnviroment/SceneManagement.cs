using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : Singleton<SceneManagement>
{
    public string SceneTransitionName { get; private set; }
    public void SetTransitionName(string name)
    {
        SceneTransitionName = name;
    }
    public void LoadSceneAdditiveAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public void UnloadSceneAsync(string sceneName)
    {
        StartCoroutine(UnloadSceneAsyncProcess(sceneName));
    }
    IEnumerator UnloadSceneAsyncProcess(string sceneName)
    {
        Scene sceneToUnload = SceneManager.GetSceneByName(sceneName);
        if (!sceneToUnload.IsValid() || !sceneToUnload.isLoaded)
        {
            Debug.LogWarning("Scene '" + sceneName + "' is not valid or not loaded.");
            yield break;
        }
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
    }
}

