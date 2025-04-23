using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinero : MonoBehaviour
{
    public int dinero = 0;
    public delegate void DineroCambio(int nuevoDinero);
    public event DineroCambio dineroCambio;
    public void SumarDinero(int cantidad)
    {
        dinero += cantidad;
        dineroCambio?.Invoke(dinero);
    }
    public void RestarDinero(int cantidad)
    {
        dinero -= cantidad;
        dineroCambio?.Invoke(dinero);
    }
}

