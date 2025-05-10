using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; 
    public GameObject Inventario;
    public GameObject Equipo;
    private PlayerControls controls;
    public MenuPlayerStats menuPlayerStats;
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.OpenMenu.performed += ctx => OpenMenu();
    }
    private void OpenMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        Inventario.SetActive(false);
        Equipo.SetActive(false);
        menuPlayerStats.StatsPlayerMenu();
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
