using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEquipo : MonoBehaviour
{
    public GameObject equipo; 
    public void Open()
    {
        equipo.SetActive(true);
        GameObject panelMenu = transform.parent.gameObject;
        panelMenu.SetActive(false);
        Debug.Log("Se hizo clic");

    }
}
