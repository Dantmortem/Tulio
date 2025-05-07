using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour
{
    public Item item;
    public Button botonSlot;
    public Image imagenSlot;
    public TMPro.TextMeshProUGUI textoCantidad;
    public GameObject panelOpciones;
    public GameObject panelInformacion;
    public InventarioController controller;
    void Start()
    {
        botonSlot = GetComponent<Button>();
        botonSlot.onClick.AddListener(MostrarOpciones);
        GameObject panelOpcionesObj = transform.Find("OptionsSlot").gameObject;
        Button botonInformacion = panelOpcionesObj.transform.Find("BotonInformacion").GetComponent<Button>(); // reemplaza "BotonInformacion" con el nombre real
        botonInformacion.onClick.AddListener(AbrirInformacion);

    }
    public void MostrarOpciones()
    {
        if (item != null)
        {
            controller.MostrarPanelOpciones(this);
            botonSlot.interactable = false;
            GameObject panelOpcionesObj = transform.Find("OptionsSlot").gameObject;
            panelOpcionesObj.GetComponent<CanvasGroup>().blocksRaycasts = true; // Esto bloquea los clics hacia abajo
            Invoke("AsignarEventoBotonInformacion", 0.1f);
        }
    }
    public void AsignarEventoBotonInformacion()
    {
        Debug.Log("AbrirInformacion ejecutado");
        controller.MostrarPanelInformacion(item);
        GameObject panelOpcionesObj = transform.Find("OptionsSlot").gameObject;
        Debug.Log("Panel de opciones encontrado: " + panelOpcionesObj.name);
        Button botonInformacion = panelOpcionesObj.transform.Find("BotonInformacion").GetComponent<Button>();
        Debug.Log("Botón Información encontrado: " + botonInformacion);
        if(botonInformacion != null)
        {
            botonInformacion.onClick.AddListener(() => AbrirInformacion());
            Debug.Log("Evento asignado correctamente");
        }
        else
        {
            Debug.Log("Botón Información no encontrado");
        }
        botonSlot.interactable = true; // reactiva el botón del slot si se cierra el panel
        controller.OcultarPanelOpciones();

    }

    public void AbrirInformacion()
    {
        Debug.Log("AbrirInformacion se ejecuta");
        controller.MostrarPanelInformacion(item);
    }
    public void EquiparItem()
    {
        // Aquí irá el código para equipar el item
    }
    public void ActualizarSlot()
    {
        if (item != null)
        {
            imagenSlot.sprite = item.imagen;
            if (item.esAcumulable)
            {
                textoCantidad.text = item.cantidad.ToString();
                textoCantidad.enabled = true;
            }
            else
            {
                textoCantidad.enabled = false;
            }
        }
        else
        {
            imagenSlot.sprite = null;
            textoCantidad.enabled = false;
        }
    }
}



