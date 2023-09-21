using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] public GameObject Window;
    [SerializeField] private Animator _windowToShow;
    private Animator _windowToHide;

    void Start()
    {
        _windowToHide = Window.GetComponent<Animator>(); 
    }

    public void backButtonAnimation()
    {
        _windowToShow.SetTrigger("Show");
        _windowToHide.SetTrigger("Hide");
    }
 }
