using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EspadaDePiedra : Arma
{
    public EspadaDePiedra()
    {
        nombre = "Espada de Piedra";
        tipo = ItemType.Arma;
        fuerza = 8;
        vitalidad = 3;
    }
}
