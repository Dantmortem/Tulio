using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public PlayerStats jugadorStats;
    public EnemyStats enemigoStats;
    public Button botonAtaque;
    public Button botonAtaqueEspecial;
    public TMPro.TextMeshProUGUI textoInformacion;
    public bool esTurnoJugador = true;
    public Vector3 posicionAnteriorBatalla;
    public Camera cameramain;
    public Camera camarabatalla;
    public GameObject panelbatalla;
    public PlayerController playerController;
    public MenuPlayerStats menuPlayerStats;
    void Start()
    {
        botonAtaque.onClick.AddListener(() => JugadorAtaca(false));
        botonAtaqueEspecial.onClick.AddListener(() => JugadorAtaca(true));
        Debug.Log("Botón Ataque asignado: " + (botonAtaque != null));
        Debug.Log("Botón Ataque Especial asignado: " + (botonAtaqueEspecial != null));
        Debug.Log("Método JugadorAtaca asignado a Botón Ataque: " + botonAtaque.onClick.GetPersistentEventCount());
        Debug.Log("Método JugadorAtaca asignado a Botón Ataque Especial: " + botonAtaqueEspecial.onClick.GetPersistentEventCount());
    }
    public void IniciarBatalla(EnemyStats enemigoStats)
    {
        this.enemigoStats = enemigoStats;
        textoInformacion.text = "¡Comienza la batalla!";
    }
    public void JugadorAtaca(bool esAtaqueEspecial)
    {
        Debug.Log("Ataque realizado");
        float dañoUsado;
        if (esAtaqueEspecial)
        {
            if (jugadorStats.mana >= 25)
            {
                jugadorStats.mana -= 25;
                dañoUsado = jugadorStats.DañoEspecialTotal;
            }
            else
            {
                textoInformacion.text = "No tienes suficiente maná para realizar el ataque especial";
                return;
            }
        }
        else
        {
            dañoUsado = jugadorStats.DañoTotal;
        }
        enemigoStats.VidaTotal -= Mathf.Max(dañoUsado * (1 - Mathf.Pow((enemigoStats.DefensaTotal / 100.0f), 0.8f)), 0);
        StartCoroutine(MostrarMensaje("Infligiste " + Mathf.RoundToInt(dañoUsado * (1 - Mathf.Pow((enemigoStats.DefensaTotal / 100.0f), 0.8f))) + " puntos de daño al enemigo", 4f));
    }
    public void EnemigoAtaca()
    {
        bool esAtaqueEspecial = Random.value < 0.3f;
        float dañoUsado;
        if (esAtaqueEspecial)
        {
            if (enemigoStats.mana >= 25)
            {
                enemigoStats.mana -= 25;
                dañoUsado = enemigoStats.DañoEspecialTotal;
            }
            else
            {
                esAtaqueEspecial = false;
                dañoUsado = enemigoStats.DañoTotal;
            }
        }
        else
        {
            dañoUsado = enemigoStats.DañoTotal;
        }
        jugadorStats.VidaTotal -= Mathf.Max(dañoUsado * (1 - Mathf.Pow((jugadorStats.DefensaTotal / 100.0f), 0.8f)), 0);
        StartCoroutine(MostrarMensaje("El enemigo te infligió " + Mathf.RoundToInt(dañoUsado * (1 - Mathf.Pow((jugadorStats.DefensaTotal / 100.0f), 0.8f))) + " puntos de daño", 4f));
        menuPlayerStats.ActualizarEstadisticasJugador();
    }
    public void CambiarTurno()
    {
        esTurnoJugador = !esTurnoJugador;
        if (esTurnoJugador)
        {
            textoInformacion.text = "Turno del jugador";
        }
        else
        {
            textoInformacion.text = "Turno del enemigo";
            EnemigoAtaca();
        }
    }
    public void VerificarGanador()
    {
        if (jugadorStats.VidaTotal > 0 && enemigoStats.VidaTotal <= 0)
        {
            botonAtaque.interactable = false;
            botonAtaqueEspecial.interactable = false;
            StartCoroutine(MostrarMensaje("¡Victoria! Has derrotado al enemigo.", 2f));
            GanarPuntosAtributo();
            menuPlayerStats.ActualizarEstadisticasJugador();
        }
        else if (enemigoStats.VidaTotal > 0 && jugadorStats.VidaTotal <= 0)
        {
            botonAtaque.interactable = false;
            botonAtaqueEspecial.interactable = false;
            StartCoroutine(MostrarMensaje("¡Derrota! Has sido derrotado por el enemigo.", 2f));
        }
        else if (enemigoStats.VidaTotal <= 0 && jugadorStats.VidaTotal <= 0)
        {
            botonAtaque.interactable = false;
            botonAtaqueEspecial.interactable = false;
            StartCoroutine(MostrarMensaje("¡Empate! Ambos personajes han sido derrotados.", 2f));
        }
    }
    private void GanarPuntosAtributo()
    {
        int vitalidadGanada = Random.Range(1, 4);
        int fuerzaGanada = Random.Range(1, 4);
        int agilidadGanada = Random.Range(1, 4);
        int magiaGanada = Random.Range(1, 4);
        jugadorStats.vitalidad += vitalidadGanada;
        jugadorStats.fuerza += fuerzaGanada;
        jugadorStats.agilidad += agilidadGanada;
        jugadorStats.magia += magiaGanada;
        StartCoroutine(MostrarMensaje("Ganaste " + vitalidadGanada + " puntos de vitalidad, " + fuerzaGanada + " puntos de fuerza, " + agilidadGanada + " puntos de agilidad y " + magiaGanada + " puntos de magia.", 3f));
        menuPlayerStats.ActualizarEstadisticasJugador();
    }
    private IEnumerator MostrarMensaje(string mensaje, float tiempo)
    {
        textoInformacion.text = mensaje;
        yield return new WaitForSeconds(tiempo);
        textoInformacion.text = "";
    }
}
