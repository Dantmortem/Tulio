using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventoryPanel; 
    public void Open()
    {
        inventoryPanel.SetActive(true);
        GameObject panelMenu = transform.parent.gameObject;
        panelMenu.SetActive(false);
        Debug.Log("Se hizo clic");

    }

}
