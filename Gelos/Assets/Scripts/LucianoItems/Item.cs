using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string nombre;
    public Sprite imagen;
    public ItemType tipo;
    public enum ItemType { Moneda, Pocion, Arma }
    public bool esAcumulable;
    public int cantidad = 1;
    public int vitalidad = 0;
    public int fuerza = 0;
    public int agilidad = 0;
    public int magia = 0;
    public int daño = 0;
    public int dañoEspecial = 0;
    public int mana = 0;
    public int defensa = 0;
    public string descripcion1;
    public string descripcion2;
    public string descripcion3;
    public string descripcion4;
    public string descripcion5;


}
