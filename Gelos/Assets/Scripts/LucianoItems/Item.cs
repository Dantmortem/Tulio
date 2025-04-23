using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string nombre;
    public string descripcion;
    public Sprite imagen;
    public ItemType tipo;
    public enum ItemType { Moneda, Pocion, Arma }

}
