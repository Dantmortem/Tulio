using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioController : MonoBehaviour
{
    public GameObject[] panelOpciones;
    public GameObject panelInformacion;
    public SlotInventario[] slots;
    public SlotInventario slotActual;
    void Start()
    {
        foreach (SlotInventario slot in slots)
        {
            panelOpciones = GameObject.FindGameObjectsWithTag("PanelOpciones"); // Asigna un tag "PanelOpciones" a todos los paneles
            slot.panelInformacion = panelInformacion;
            slot.controller = this;
        }
    }
    public void MostrarPanelOpciones(SlotInventario slot)
    {
        slotActual = slot;
        Debug.Log("MostrarPanelOpciones ejecutado");
        foreach (Transform child in slot.transform)
        {
            if (child.name == "OptionsSlot") // reemplaza con el nombre real
            {
                Debug.Log("Panel de opciones encontrado");
                child.gameObject.SetActive(true);
                break;
            }
        }
}
    public void OcultarPanelOpciones()
    {
        foreach (GameObject panel in panelOpciones)
        {
            panel.SetActive(false);
            panel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        // También reactivamos el botón del slot aquí
        slotActual.botonSlot.interactable = true;

    }

    public void MostrarPanelInformacion(Item item)
    {
        OcultarPanelOpciones();
        panelInformacion.transform.SetSiblingIndex(10); // Para que se muestre encima
        panelInformacion.SetActive(true);
        panelInformacion.GetComponent<PanelInformacion>().CargarInformacion(item);
    }

}
