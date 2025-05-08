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
    public GameObject panelInformacion;
    public InventarioController controller;
    void Start()
    {
        botonSlot = GetComponent<Button>();
    }
    public void MostrarOpciones()
    {
        controller.slotActual = this;
        MostrarPanelInformacion();
    }

    public void AbrirInformacion()
    {
        Debug.Log("AbrirInformacion se ejecuta");
        controller.MostrarPanelInformacion(item);
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
    public void MostrarPanelInformacion()
    {
        if (item != null)
        {
            panelInformacion.SetActive(true);
            panelInformacion.transform.Find("NombreObjeto").GetComponent<TMPro.TextMeshProUGUI>().text = item.nombre;
            panelInformacion.transform.Find("TextoLinea1").GetComponent<TMPro.TextMeshProUGUI>().text = item.descripcion1;
            panelInformacion.transform.Find("InfoCantidad").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.cantidad;
            // También mostraremos los botones según el tipo de objeto
            GameObject botonEquipar = panelInformacion.transform.Find("BotonEquipar").gameObject;
            GameObject botonUsar = panelInformacion.transform.Find("BotonUsar").gameObject;
            if (item.tipo == Item.ItemType.Arma)
            {
                botonEquipar.SetActive(true);
                botonUsar.SetActive(false);
            }
            else if (item.tipo == Item.ItemType.Pocion)
            {
                botonEquipar.SetActive(false);
                botonUsar.SetActive(true);
            }
        }
    }

    public void EquiparItem()
    {
        panelInformacion.SetActive(false);
    }
    public void UsarItem()
    {
        item.cantidad--;
        panelInformacion.SetActive(false);
        if (item.cantidad <= 0)
        {
            controller.EliminarItem(this);
        }
    }
}



