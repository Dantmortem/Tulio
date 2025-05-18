using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioController : MonoBehaviour
{
    public GameObject panelInformacion;
    public SlotInventario[] slots;
    public SlotInventario slotActual;
    void Start() 
    {
        foreach (SlotInventario slot in slots) 
        {
            slot.panelInformacion = panelInformacion;
            slot.controller = this;
        }
    }
    public void MostrarPanelInformacion(Item item) 
    {
        panelInformacion.SetActive(true);
    }
    public void EliminarItem(SlotInventario slot) 
    {
        if(slot.item != null) 
        {
            slot.item = null;
        }
    }
}
