using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip bonus;
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            AudioSource.PlayClipAtPoint(bonus, transform.position);
            Destroy(gameObject, 0.3f);
            
        }
    }
}
