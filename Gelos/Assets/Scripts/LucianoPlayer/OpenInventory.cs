using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject Inventario; 
    public void Open()
    {
        Inventario.SetActive(true);
        GameObject panelMenu = transform.parent.gameObject;
        panelMenu.SetActive(false);
    }

}
