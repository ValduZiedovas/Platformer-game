using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathandWinsoundplay : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.name == "") //á kabutes reik áraðyti þaidëjo pavadinimà(gameObject) jei dësi ant teleporteriø, spàstø ir t. t.
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
