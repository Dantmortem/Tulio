using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Arma : Item 
{
    public int vitalidad = 0;
    public int fuerza = 0;
    public int agilidad = 0;
    public int magia = 0;
    public Arma() 
    {
        tipo = Item.ItemType.Arma;
    }
}

