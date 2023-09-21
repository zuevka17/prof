using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudetnsWindows : MonoBehaviour
{
    [SerializeField] private Animator _studentsWindow;
    [SerializeField] private Animator _theoryWindow;
    [SerializeField] private Animator _ControlWindow;
    [SerializeField] private Animator _testWindow;

    public void SwitchToTheory()
    {
        _theoryWindow.SetTrigger("Show");
    }
    public void SwitchToTest()
    {
        _testWindow.SetTrigger("Show");
    }
    public void SwitchToControlTest()
    {
        _ControlWindow.SetTrigger("Show");
    }


    public void HideStudentsWindow()
    {
        _studentsWindow.SetTrigger("Hide");
    }
}
