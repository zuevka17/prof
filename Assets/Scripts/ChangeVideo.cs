using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChangeVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip _videoClip;
    [SerializeField] private Slider _videoSlider;
    [SerializeField] private Button _nextButton;
    // interactable button 

    void Update()
    {
        if (_videoSlider.value >= _videoSlider.maxValue * 0.9f)
        {
            _nextButton.interactable = true;
        }
    }
    public void PlayVideo()
    {
        _videoPlayer.clip = _videoClip;
        _videoPlayer.Play();
    }
}
