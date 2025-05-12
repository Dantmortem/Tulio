using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanuraArmaController : MonoBehaviour
{
    public Item itemActual; // Variable para almacenar el item actual en la ranura de arma
    public GameObject panel;
    public RanuraArmaController ranuraArmaController;

    public void Open()
    {
        if (ranuraArmaController.itemActual != null)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
