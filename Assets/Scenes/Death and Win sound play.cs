using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathandWinsoundplay : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.name == "") //� kabutes reik �ra�yti �aid�jo pavadinim�(gameObject) jei d�si ant teleporteri�, sp�st� ir t. t.
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
