using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController playerController;
    public Camera camaraCombate;
    public Camera cameramain;
    public GameObject panelbatalla;
    public BattleManager battleManager;
    private Vector3 posicionAnteriorBatalla;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            posicionAnteriorBatalla = transform.position;
            EnemyStats enemigoStats = collision.gameObject.GetComponentInChildren<EnemyStats>();
            battleManager.enemyAnimator = collision.gameObject.GetComponentInChildren<Animator>();
            battleManager.posicionAnteriorBatalla = posicionAnteriorBatalla;
            battleManager.enemigoStats = enemigoStats;
            IniciarCombate(collision.gameObject);
        }
    }
    private void IniciarCombate(GameObject Enemy)
    {
        UIFade.Instance.estaActivo = true;
        UIFade.Instance.FadeToBlack();
        StartCoroutine(TransportarACombate(Enemy));

    }
    private IEnumerator TransportarACombate(GameObject Enemy)
    {
        yield return new WaitForSeconds(1f);
        cameramain.enabled = false;
        panelbatalla.SetActive(true);
        camaraCombate.enabled = true;
        playerController.cameramain = camaraCombate;
        float PosicionX = -36f;
        float PosicionY = 5f;
        transform.position = new Vector3(PosicionX, PosicionY, 0);
        float offsetX = 8f;
        Enemy.transform.position = new Vector3(PosicionX + offsetX, PosicionY, 0);
        playerController.isMovementEnabled = false;
        UIFade.Instance.FadeToClear();
        UIFade.Instance.estaActivo = false;
        EnemyStats enemigoStats = Enemy.GetComponentInChildren<EnemyStats>();
        battleManager.enemyAnimator = Enemy.GetComponentInChildren<Animator>();
        battleManager.IniciarBatalla(battleManager.enemigoStats);
    }

}
