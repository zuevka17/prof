using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChangeVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip _videoClip;

    public void PlayVideo()
    {
        _videoPlayer.clip = _videoClip;
        _videoPlayer.Play();
    }
}
