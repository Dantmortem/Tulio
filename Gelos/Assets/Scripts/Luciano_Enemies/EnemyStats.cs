using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float vitalidad = 10;
    public float fuerza = 10;
    public float agilidad = 10;
    public float magia = 10;
    public float vida = 100;
    public float mana = 100;
    public float daño = 10;
    public float dañoEspecial = 15;
    public float defensa = 5;
    public float VidaMaxima { get { return vida + (vitalidad * 10) / 100 * vida; } }
    public float ManaTotal { get { return mana + (magia * 10) / 100 * mana; } }
    public float DañoTotal { get { return daño + (fuerza * 8) / 100 * daño + (vitalidad * 2) / 100 * daño; } }
    public float DañoEspecialTotal { get { return dañoEspecial + (fuerza * 5) / 100 * dañoEspecial + (magia * 8) / 100 * dañoEspecial; } }
    public float DefensaTotal { get { return defensa + (agilidad * 10) / 100 * defensa; } }
    public float VidaTotal { get; set; }
    private void Start()
    {
        VidaTotal = VidaMaxima;
    }

}
