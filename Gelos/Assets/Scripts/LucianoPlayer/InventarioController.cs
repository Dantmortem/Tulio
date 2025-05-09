using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioController : MonoBehaviour
{
    public GameObject panelInformacion; // Referencia al panel de información del inventario
    public SlotInventario[] slots; // Arreglo de slots del inventario
    public SlotInventario slotActual; // Slot actualmente seleccionado
    void Start() 
    {
        foreach (SlotInventario slot in slots) 
        {
            slot.panelInformacion = panelInformacion; // Asigna el panel de información al slot
            slot.controller = this; // Asigna el controlador del inventario al slot
        }
    }
    public void MostrarPanelInformacion(Item item) 
    {
        panelInformacion.SetActive(true); // Activa el panel de información
    }
    public void EliminarItem(SlotInventario slot) 
    {
        if(slot.item != null) 
        {
            slot.item = null; // Elimina el item del slot
        }
    }
}
