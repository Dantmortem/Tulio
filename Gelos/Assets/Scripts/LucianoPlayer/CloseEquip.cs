using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEquip : MonoBehaviour
{
    public GameObject equipo; 
    public GameObject panelMenu;
    public void Close()
    {
        equipo.SetActive(false);
        panelMenu.SetActive(true);
    }
}
