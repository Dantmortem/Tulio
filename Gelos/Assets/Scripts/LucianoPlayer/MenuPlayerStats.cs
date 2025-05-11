using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayerStats : MonoBehaviour
{
    public PlayerStats playerstats;
    public GameObject panel;

    public void StatsPlayerMenu() 
    {
        panel.transform.Find("InfoVitalidadPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.vitalidad;
        panel.transform.Find("InfoFuerzaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.fuerza;
        panel.transform.Find("InfoAgilidadPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.agilidad;
        panel.transform.Find("InfoMagiaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.magia;
        panel.transform.Find("InfoPuntosDeVidaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.VidaTotal;
        panel.transform.Find("InfoDañoPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.DañoTotal;
        panel.transform.Find("InfoDañoEspecialPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.DañoEspecialTotal;
        panel.transform.Find("InfoManáPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.ManaTotal;
        panel.transform.Find("InfoDefensaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.DefensaTotal;
    }
    public void ActualizarEstadisticasJugador() 
    {
        panel.transform.Find("InfoVitalidadPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.vitalidad;
        panel.transform.Find("InfoFuerzaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.fuerza;
        panel.transform.Find("InfoAgilidadPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.agilidad;
        panel.transform.Find("InfoMagiaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.magia;
        panel.transform.Find("InfoPuntosDeVidaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.VidaTotal;
        panel.transform.Find("InfoDañoPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.DañoTotal;
        panel.transform.Find("InfoDañoEspecialPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.DañoEspecialTotal;
        panel.transform.Find("InfoManáPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.ManaTotal;
        panel.transform.Find("InfoDefensaPlayer").GetComponent<TMPro.TextMeshProUGUI>().text = "" + playerstats.DefensaTotal;
    }
}
