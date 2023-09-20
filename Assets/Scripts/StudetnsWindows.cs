using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudetnsWindows : MonoBehaviour
{
    [SerializeField] private Animator _studentsWindow;
    [SerializeField] private Animator _theoryWindow;
    [SerializeField] private Animator _trainWindow;
    [SerializeField] private Animator _testWindow;

    public void SwitchToTheory()
    {
        _theoryWindow.SetBool("IsTheoryWindow", true);
    }
    public void HideStudentsWindow()
    {
        _studentsWindow.SetBool("IsUserWindow", false);
    }
}
