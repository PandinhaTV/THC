using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLvl : MonoBehaviour
{
    public AudioSource audioSource;
    public float interval = 30f; // Time between events in seconds

    private float nextTriggerTime = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Load the next scene (by build index)
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
    }

    private void Update()
    {
        if (audioSource.isPlaying)
        {
            if (audioSource.time < nextTriggerTime - interval)
            {
                // Song looped, reset trigger time
                nextTriggerTime = interval;
            }

            if (audioSource.time >= nextTriggerTime)
            {
                TriggerEvent();
                nextTriggerTime += interval;
            }
        }
    }
    void TriggerEvent()
    {
        // Replace this with whatever you want to do every 30 seconds
        audioSource.Play();
        Debug.Log("Triggered at: " + audioSource.time + " seconds");
    }
}
