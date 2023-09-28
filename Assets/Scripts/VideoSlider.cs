using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoSlider : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Slider videoProgressBar;


    public void SetMaxValueForSlider()
    {
        videoProgressBar.maxValue = (float)videoPlayer.clip.length;
    }

    public void OnProgressBarDownClicked()
    {
        if (videoPlayer.isPaused)
            videoPlayer.time = (float)videoProgressBar.value;
    }

    void Update()
    {
        if(!videoPlayer.isPaused)
            videoProgressBar.value = (float)videoPlayer.time;
    }
}
