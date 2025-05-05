using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInformation : MonoBehaviour
{
    public GameObject panelinformacion;

    public void Close() {
        panelinformacion.SetActive(false);
    }
}
