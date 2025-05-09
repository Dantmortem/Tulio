using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseInformation : MonoBehaviour
{
    public GameObject panelinformacion;
    public void Close()
    {
        panelinformacion.SetActive(false);
    }

    void Start()
    {
        Debug.Log("Script iniciado");
    }
}
