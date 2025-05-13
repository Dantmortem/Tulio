using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRanuraArma : MonoBehaviour
{
    public Button botonDesequipar;
    public Button botonCerrar;
    public GameObject panel;
    public InventarioController controller;
    public RanuraArmaController ranuraArmaController;
    public PlayerStats jugador;
    public MenuPlayerStats menuPlayerStats;
    private void Start()
    {
        botonDesequipar.onClick.AddListener(DesequiparArma);
        botonCerrar.onClick.AddListener(CerrarPanel);
    }
    public void DesequiparArma()
    {
        jugador.vitalidad -= ranuraArmaController.itemActual.vitalidad;
        jugador.fuerza -= ranuraArmaController.itemActual.fuerza;
        jugador.agilidad -= ranuraArmaController.itemActual.agilidad;
        jugador.magia -= ranuraArmaController.itemActual.magia;
        jugador.daño -= ranuraArmaController.itemActual.daño;
        jugador.dañoEspecial -= ranuraArmaController.itemActual.dañoEspecial;
        jugador.mana -= ranuraArmaController.itemActual.mana;
        jugador.defensa -= ranuraArmaController.itemActual.defensa;
        jugador.vida -= ranuraArmaController.itemActual.puntosdevida;
        menuPlayerStats.ActualizarEstadisticasJugador();
        DevolverObjetoAlInventario();
        this.ranuraArmaController.itemActual = null;
        CerrarPanel();
        ranuraArmaController.transform.Find("ArmaImage").GetComponent<Image>().sprite = null;
    }
    private void DevolverObjetoAlInventario()
    {
        SlotInventario slotVacio = EncontrarSlotVacioEnInventario();
        slotVacio.item = ranuraArmaController.itemActual;
        slotVacio.gameObject.transform.Find(slotVacio.name + "Image").GetComponent<Image>().sprite = ranuraArmaController.itemActual.imagen;
    }
    private SlotInventario EncontrarSlotVacioEnInventario()
    {
        foreach (SlotInventario slot in controller.slots)
        {
            if (slot.item == null)
            {
                return slot;
            }
        }
        return null;
    }
    private void CerrarPanel()
    {
        panel.SetActive(false);
    }

}
