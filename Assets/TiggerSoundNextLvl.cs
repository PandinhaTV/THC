using System;
using UnityEngine;

public class TiggerSoundNextLvl : MonoBehaviour
{
    public AudioSource clip;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            clip.Play();
        }
    }
}
