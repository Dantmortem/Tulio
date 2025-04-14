using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos_Armas : MonoBehaviour
{
    [SerializeField] AudioSource sound;

    [SerializeField] AudioClip ataque, defensa; 

    public void SonidoAtaque()
    {
        sound.PlayOneShot(ataque);
    }

    public void SonidoDefensa()
    {
        sound.PlayOneShot(defensa);
    }
}
