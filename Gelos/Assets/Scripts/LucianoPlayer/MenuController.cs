using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; 
    public GameObject inventoryPanel;

    private PlayerControls controls;
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.OpenMenu.performed += ctx => OpenMenu();
    }
    private void OpenMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        inventoryPanel.SetActive(false);

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
