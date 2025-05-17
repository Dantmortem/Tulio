using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int vitalidad = 10;
    public int fuerza = 10;
    public int agilidad = 10;
    public int magia = 10;
    public int vida = 100;
    public int mana = 100;
    public int daño = 10;
    public int dañoEspecial = 15;
    public int defensa = 5;
    public int VidaTotal { get { return vida + (vitalidad * 10) / 100 * vida;}}
    public int ManaTotal { get { return mana + (magia * 10) / 100 * mana;}}
    public int DañoTotal { get { return daño + (fuerza * 8) / 100 * daño + (vitalidad * 2) / 100 * daño;}}
    public int DañoEspecialTotal { get { return dañoEspecial + (fuerza * 5) / 100 * dañoEspecial + (magia * 8) / 100 * dañoEspecial;}}
    public int DefensaTotal { get { return defensa + (agilidad * 10) / 100 * defensa;}}
}
