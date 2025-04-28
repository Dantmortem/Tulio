using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    public GameObject Inventario; 
    public GameObject panelMenu;
    public void Close()
    {
        Inventario.SetActive(false);
        panelMenu.SetActive(true);

    }

}
