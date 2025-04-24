using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DineroUI : MonoBehaviour
{
    public Dinero dineroScript; // Referencia al script Dinero
    private Text textoDinero; // Referencia al texto del dinero
    void Start() 
{
    textoDinero = GameObject.Find("Texto_Dinero")?.GetComponent<Text>();
    if(textoDinero != null && dineroScript != null)
    {
        textoDinero.text = "Dinero: " + dineroScript.dinero.ToString();
        dineroScript.dineroCambio += ActualizarTextoDinero;
    }
}

    void OnDestroy()
    {
        dineroScript.gameObject.GetComponent<Dinero>().dineroCambio -= ActualizarTextoDinero;
    }
    void ActualizarTextoDinero(int nuevoDinero)
    {
        textoDinero.text = nuevoDinero.ToString();
    }
}


