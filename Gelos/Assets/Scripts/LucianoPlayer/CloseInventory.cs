using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    public GameObject inventoryPanel; 
    public GameObject panelMenu;
    public void Close()
    {
        inventoryPanel.SetActive(false);
        panelMenu.SetActive(true);

    }

}
