using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AreaExit : MonoBehaviour 
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    private string escenaActual;
    private float waitToLoadTime = 1f;
    private void Start() 
    {
        // Obtener la escena actual
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene escena = SceneManager.GetSceneAt(i);
            if (escena.name != "Luciano_Player" && escena.isLoaded) // Reemplaza con el nombre real de tu escena del jugador
            {
                escenaActual = escena.name;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<PlayerController>()) 
        {
            UIFade.Instance.FadeToBlack();
            StartCoroutine(WaitAndLoad());
        }
    }
    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1f);
        SceneManagement.Instance.UnloadSceneAsync(escenaActual);
        SceneManagement.Instance.LoadSceneAdditiveAsync(sceneToLoad);
        SceneManagement.Instance.SetTransitionName(sceneTransitionName);
    }


}

