using UnityEngine;

public class AudioBoombox : MonoBehaviour
{
    public AudioClip[] songs;           // Assign your songs in the Inspector
       private AudioSource audioSource;
       private int lastIndex = -1;
       private bool songFinished = true;
       private bool isPaused = false;
       void Start()
       {
           audioSource = GetComponent<AudioSource>();
           PlayRandomSong();
       }

       void Update()
       {
           // Auto-play next song when the current one ends (if not paused)
           if (!audioSource.isPlaying && !songFinished && !isPaused)
           {
               songFinished = true;
               PlayRandomSong();
           }
       }
       public void Play()
       {
           PlayRandomSong();
       }
       void PlayRandomSong()
       {
           if (songs.Length == 0) return;

           int newIndex;

           // Ensure it's a different song than last time
           do
           {
               newIndex = Random.Range(0, songs.Length);
           } while (songs.Length > 1 && newIndex == lastIndex);

           lastIndex = newIndex;
           audioSource.clip = songs[newIndex];
           audioSource.Play();
           songFinished = false;

           Debug.Log("Now playing: " + songs[newIndex].name);
       }
       public void TogglePause()
       {
           if (!audioSource.isPlaying && !isPaused)
               return; // No song playing, can't pause

           if (isPaused)
           {
               audioSource.UnPause();
               isPaused = false;
               Debug.Log("Music resumed");
           }
           else
           {
               audioSource.Pause();
               isPaused = true;
               Debug.Log("Music paused");
           }
       }
}
