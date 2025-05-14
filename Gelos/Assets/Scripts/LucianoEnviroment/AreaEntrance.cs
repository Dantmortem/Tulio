using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AreaEntrance : MonoBehaviour 
{
    [SerializeField] private string sceneTransitionName;
    private void Start() 
    {
        if (SceneManagement.Instance.SceneTransitionName == sceneTransitionName)
        {
            PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.transform.position = transform.position;
            SceneManagement.Instance.SetTransitionName("");
            UIFade.Instance.FadeToClear(); // Activar fade a claro
        }
    }

}

