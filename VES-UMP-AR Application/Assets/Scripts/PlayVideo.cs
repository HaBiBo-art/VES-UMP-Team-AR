using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PlayVideoClip()
    {
        // Stop the video if it's playing
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }

        // Set the video to start from the beginning
        videoPlayer.time = 0;
        videoPlayer.Play();
    }
}

