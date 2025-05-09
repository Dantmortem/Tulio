using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaInventario : MonoBehaviour
{
    public SlotInventario[] Slots = new SlotInventario[87]; 
    public EspadaDeMadera EspadaDeMadera;
    public EspadaDePiedra EspadaDePiedra;
    public PocionDeSalud PocionDeSalud;
    public PocionDeManá PocionDeManá;
    void Start()
    {
        PocionDeSalud.esAcumulable = true;
        PocionDeSalud.cantidad = 5;
        PocionDeManá.esAcumulable = true;
        PocionDeManá.cantidad = 5;

        Slots[0].item = EspadaDeMadera;
        Slots[1].item = PocionDeSalud;
        Slots[2].item = EspadaDePiedra;
        Slots[3].item = PocionDeManá;

        foreach (SlotInventario slot in Slots)
        {
            slot.ActualizarSlot();
        }
    }

}

