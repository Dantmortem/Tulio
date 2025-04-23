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
        textoDinero = GameObject.Find("Texto_Dinero").GetComponent<Text>();
        textoDinero.text = "Dinero: " + dineroScript.dinero.ToString();
        dineroScript.gameObject.GetComponent<Dinero>().dineroCambio += ActualizarTexto;
    }
    void OnDestroy()
    {
        dineroScript.gameObject.GetComponent<Dinero>().dineroCambio -= ActualizarTexto;
    }
    void ActualizarTexto(int nuevoDinero)
    {
        textoDinero.text = nuevoDinero.ToString();
    }
}


