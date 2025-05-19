using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAllScenes : MonoBehaviour
{
    [SerializeField] ScenesList[] scenesList;
    public static Dictionary<string, bool> escenasCargadas = new Dictionary<string, bool>();
    void Start()
    {
        if (SceneManager.sceneCount > 1) return;
        foreach (ScenesList scene in scenesList)
        {
            if (scene.isLoaded && !escenasCargadas.ContainsKey(scene.sceneName))
            {
                SceneManager.LoadScene(scene.sceneName, LoadSceneMode.Additive);
                escenasCargadas.Add(scene.sceneName, true);
            }
        }
    }
    [System.Serializable]
    public class ScenesList
    {
        public string sceneName;
        public bool isLoaded;
    }
}

