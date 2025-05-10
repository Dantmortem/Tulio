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
    public PlayerStats jugador;
    public MenuPlayerStats menuPlayerStats;
    public GameObject ranuraArma;

    void Start()
    {
        Debug.Log("Jugador: " + jugador);
        botonSlot = GetComponent<Button>();
        if (panelInformacion.transform.Find("BotonEquipar").gameObject.GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            GameObject botonEquipar = panelInformacion.transform.Find("BotonEquipar").gameObject;
            botonEquipar.GetComponent<Button>().onClick.AddListener(EquiparObjeto);
        }

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
        item = (Item)this.gameObject.GetComponent<SlotInventario>().item;
        if (item != null)
        {
            panelInformacion.SetActive(true);
            panelInformacion.transform.Find("NombreObjeto").GetComponent<TMPro.TextMeshProUGUI>().text = item.nombre;
            panelInformacion.transform.Find("TextoLinea1").GetComponent<TMPro.TextMeshProUGUI>().text = item.descripcion1;
            panelInformacion.transform.Find("InfoCantidad").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.cantidad;
            panelInformacion.transform.Find("InfoVitalidad").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.vitalidad;
            panelInformacion.transform.Find("InfoFuerza").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.fuerza;
            panelInformacion.transform.Find("InfoAgilidad").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.agilidad;
            panelInformacion.transform.Find("InfoMagia").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.magia;
            panelInformacion.transform.Find("InfoDaño").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.daño;
            panelInformacion.transform.Find("InfoDañoEspecial").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.dañoEspecial;
            panelInformacion.transform.Find("InfoManá").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.mana;
            panelInformacion.transform.Find("InfoDefensa").GetComponent<TMPro.TextMeshProUGUI>().text = "" + item.defensa;
            panelInformacion.transform.Find("ImagenObjeto").GetComponent<Image>().sprite = item.imagen;
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
    public void UsarItem()
    {
        item.cantidad--;
        panelInformacion.SetActive(false);
        if (item.cantidad <= 0)
        {
            controller.EliminarItem(this);
        }
    }
    public void EquiparObjeto()
    {
        Debug.Log("Item: " + item);
        jugador.vitalidad += item.vitalidad;
        jugador.fuerza += item.fuerza;
        jugador.agilidad += item.agilidad;
        jugador.magia += item.magia;
        jugador.daño += item.daño;
        jugador.dañoEspecial += item.dañoEspecial;
        jugador.mana += item.mana;
        jugador.defensa += item.defensa;
        menuPlayerStats.ActualizarEstadisticasJugador();
        panelInformacion.SetActive(false);
        this.item = null;
        GameObject ArmaImage = ranuraArma.transform.Find("ArmaImage").gameObject;
        ArmaImage.GetComponent<Image>().sprite = item.imagen;
    }
    

}



