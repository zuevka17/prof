using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    void Update()
    {
        PlayAndPause();
    }
    private void PlayAndPause()
    {
        if(Input.GetKeyDown("space"))
        {
            if (_videoPlayer.isPlaying)
            {
                _videoPlayer.Pause();
            }
            else
            {
                _videoPlayer.Play();
            }
        }
    }
}
