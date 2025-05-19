using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum BattleStatus 
{
    Turno_Jugador,
    Turno_Enemigo,
    Esperando_Accion,
    Verificando_Victoria,
    Siguiente_Turno
}
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
    private BattleStatus battleStatus;
    private bool isCombatActive;
    public Animator jugadorAnimator;
    public Animator enemyAnimator;
    public UIFade uIFade;
    void Start()
    {
        isCombatActive = true;
        battleStatus = BattleStatus.Siguiente_Turno;
        botonAtaque.onClick.AddListener(() => JugadorAtaca(false));
        botonAtaqueEspecial.onClick.AddListener(() => JugadorAtaca(true));
        StartCoroutine(CombatLoop());
    }
    public void IniciarBatalla(EnemyStats enemigoStats)
    {
        this.enemigoStats = enemigoStats;
        textoInformacion.text = "¡Comienza la batalla!";
        isCombatActive = true;
        battleStatus = BattleStatus.Siguiente_Turno;
        StopAllCoroutines();
        StartCoroutine(CombatLoop());
    }
    public void JugadorAtaca(bool esAtaqueEspecial)
    {
        float dañoUsado;
        if (esAtaqueEspecial)
        {
            if (jugadorStats.mana >= 25)
            {
                jugadorStats.mana -= 25;
                dañoUsado = jugadorStats.DañoEspecialTotal;
                jugadorAnimator.SetTrigger("AtaqueEspecial");
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
            jugadorAnimator.SetTrigger("Ataque");
        }
        enemigoStats.VidaTotal -= Mathf.Max(dañoUsado * (1 - Mathf.Pow((enemigoStats.DefensaTotal / 100.0f), 0.8f)), 0);
        botonAtaque.interactable = false;
        botonAtaqueEspecial.interactable = false;
        StartCoroutine(MostrarMensaje("Infligiste " + Mathf.RoundToInt(dañoUsado * (1 - Mathf.Pow((enemigoStats.DefensaTotal / 100.0f), 0.8f))) + " puntos de daño al enemigo", 2f));
        battleStatus = BattleStatus.Turno_Enemigo;
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
                enemyAnimator.SetTrigger("AtaqueEspecialE");
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
            enemyAnimator.SetTrigger("AtaqueE");
        }
        jugadorStats.VidaTotal -= Mathf.Max(dañoUsado * (1 - Mathf.Pow((jugadorStats.DefensaTotal / 100.0f), 0.8f)), 0);
        StartCoroutine(MostrarMensaje("El enemigo te infligió " + Mathf.RoundToInt(dañoUsado * (1 - Mathf.Pow((jugadorStats.DefensaTotal / 100.0f), 0.8f))) + " puntos de daño", 2f));
        battleStatus = BattleStatus.Verificando_Victoria;
    }
    private void SiguienteTurno()
    {
        if (battleStatus == BattleStatus.Siguiente_Turno)
        {
            StartCoroutine(MostrarMensaje("Turno del jugador", 2f));
            battleStatus = BattleStatus.Turno_Jugador;
            botonAtaque.interactable = true;
            botonAtaqueEspecial.interactable = true;
        }
    }
    private void VerificarVictoria()
    {
        if (jugadorStats.VidaTotal > 0 && enemigoStats.VidaTotal <= 0)
        {
            enemyAnimator.SetTrigger("MorirE");
            textoInformacion.text = "¡Victoria! Has derrotado al enemigo.";
            StartCoroutine(EsperarGanarAtributos());
            isCombatActive = false;
        }
        else if (enemigoStats.VidaTotal > 0 && jugadorStats.VidaTotal <= 0)
        {
            jugadorAnimator.SetTrigger("Morir");
            textoInformacion.text = "¡Derrota! Has sido derrotado por el enemigo.";
            isCombatActive = false;
        }
        else
        {
            battleStatus = BattleStatus.Siguiente_Turno;
        }
    }
    private IEnumerator CombatLoop()
    {
        while (isCombatActive)
        {
            switch (battleStatus)
            {
                case BattleStatus.Turno_Jugador:
                    yield return new WaitForSeconds(2f);
                    yield return null;
                    break;
                case BattleStatus.Turno_Enemigo:
                    EnemigoAtaca();
                    yield return new WaitForSeconds(2f);
                    yield return null;
                    break;
                case BattleStatus.Esperando_Accion:
                    yield return null;
                    break;
                case BattleStatus.Verificando_Victoria:
                    VerificarVictoria();
                    yield return new WaitForSeconds(3f);
                    yield return null;
                    break;
                case BattleStatus.Siguiente_Turno:
                    SiguienteTurno();
                    yield return new WaitForSeconds(2f);
                    yield return null;
                    break;
            }
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
    private IEnumerator MostrarMensajeYEsperar(string mensaje, float tiempo, BattleStatus siguienteEstado)
    {
        textoInformacion.text = mensaje;
        yield return new WaitForSeconds(tiempo);
        textoInformacion.text = "";
        battleStatus = siguienteEstado;
    }
    private IEnumerator EsperarGanarAtributos()
    {
        yield return new WaitForSeconds(3f);
        GanarPuntosAtributo();
        uIFade.FadeToBlack();
        yield return new WaitForSeconds(2f);
        botonAtaque.interactable = true;
        botonAtaqueEspecial.interactable = true;
        playerController.transform.position = posicionAnteriorBatalla;
        playerController.isMovementEnabled = true;
        Destroy(enemigoStats.gameObject.transform.parent.gameObject);
        cameramain.enabled = true;
        panelbatalla.SetActive(false);
        camarabatalla.enabled = false;
        playerController.cameramain = cameramain;
        uIFade.FadeToClear();
        UIFade.Instance.estaActivo = true;
    }
}
