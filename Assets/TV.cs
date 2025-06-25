using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PlayTV()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        
            
    }
}
