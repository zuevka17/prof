using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAnimations : MonoBehaviour
{
    [SerializeField] private Animator _windowToHide;
    [SerializeField] private Animator _windowToShow;

    public void ShowWindow()
    {
        _windowToShow.SetTrigger("Show");
    }
    public void HideWindow()
    {
        _windowToHide.SetTrigger("Hide");
    }
}
