using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChangeVideo : MonoBehaviour
{
    [SerializeField] private DbConnect _dbConnect;
    [SerializeField] private int _videoId;
    private bool _isInserted = false;


    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip _videoClip;
    [SerializeField] private Slider _videoSlider;
    [SerializeField] private Button _nextButton;

    void Update()
    {
        if (_videoSlider.value >= _videoSlider.maxValue * 0.9f)
        {
            if (!_isInserted && _videoPlayer.clip == _videoClip)
            {
                _isInserted = true;
                _dbConnect.CreateUserWatchedVideos(_videoId);
            }

            _nextButton.interactable = true;
        }
    }
    public void PlayVideo()
    {
        _videoSlider.value = 0;
        _videoPlayer.clip = _videoClip;
        _videoPlayer.Play();
    }

}
