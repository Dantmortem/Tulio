using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelInformacion : MonoBehaviour
{
    public TMPro.TextMeshProUGUI InfoVitalidad;
    public TMPro.TextMeshProUGUI InfoFuerza;
    public TMPro.TextMeshProUGUI infoAgilidad;
    public TMPro.TextMeshProUGUI InfoMagia;
    public TMPro.TextMeshProUGUI InfoDaño;
    public TMPro.TextMeshProUGUI InfoDañoEspecial;
    public TMPro.TextMeshProUGUI InfoManá;
    public TMPro.TextMeshProUGUI InfoDefensa;
    public TMPro.TextMeshProUGUI TextoLinea1;
    public TMPro.TextMeshProUGUI TextoLinea2;
    public TMPro.TextMeshProUGUI TextoLinea3;
    public TMPro.TextMeshProUGUI TextoLinea4;
    public TMPro.TextMeshProUGUI TextoLinea5;
    public TMPro.TextMeshProUGUI NombreObjeto;
    public Image imagenItem;
    public void CargarInformacion(Item item)
    {
        InfoVitalidad.text = item.vitalidad.ToString();
        InfoFuerza.text = item.fuerza.ToString();
        infoAgilidad.text = item.agilidad.ToString();
        InfoMagia.text = item.magia.ToString();
        InfoDaño.text = item.daño.ToString();
        InfoDañoEspecial.text = item.dañoEspecial.ToString();
        InfoManá.text = item.mana.ToString();
        InfoDefensa.text = item.defensa.ToString();
        TextoLinea1.text = item.descripcion1;
        TextoLinea2.text = item.descripcion2;
        TextoLinea3.text = item.descripcion3;
        TextoLinea4.text = item.descripcion4;
        TextoLinea5.text = item.descripcion5;
        NombreObjeto.text = item.nombre;
        imagenItem.sprite = item.imagen;
    }

}
