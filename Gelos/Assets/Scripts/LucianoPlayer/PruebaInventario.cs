using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaInventario : MonoBehaviour
{
    public SlotInventario[] Slots; // Arrastra los slots del inventario aquí
    public EspadaDeMadera EspadaDeMadera;
    public EspadaDePiedra EspadaDePiedra;
    public PocionDeSalud PocionDeSalud;
    public PocionDeManá PocionDeManá;
    void Start()
    {
        // Asignar items a los slots
        Slots[0].item = EspadaDeMadera;
        Slots[1].item = PocionDeSalud;
        Slots[2].item = EspadaDePiedra;
        Slots[3].item = PocionDeManá;

    }

}

