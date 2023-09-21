using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminWindow : MonoBehaviour
{
    [SerializeField] private Animator _administratorWindow;
    [SerializeField] private Animator _createUserWindow;

    public void SwitchToCreateUser()
    {
        _createUserWindow.SetTrigger("Show");
    }
    public void HideAdminWindow()
    {
        _administratorWindow.SetTrigger("Hide");
    }
}
