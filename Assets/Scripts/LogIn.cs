using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogIn : MonoBehaviour
{
    [SerializeField] public string Login;
    [SerializeField] public string Password;
    [SerializeField] public string Role;


    [SerializeField] private Animator _adminWindow;
    [SerializeField] private Animator _mainWindow;
    [SerializeField] private Animator _studentWindow;
    [SerializeField] private Animator _teacherWindow;

    [SerializeField] public TMP_InputField LoginInput;
    [SerializeField] public TMP_InputField PasswordInput;   

    public void TryLogin()
    {
        if (Login == LoginInput.text && Password == PasswordInput.text)
        {
            _mainWindow.SetBool("IsHidden", true);

            if (Role == "User")
            {
                _studentWindow.SetTrigger("Show");
            }
            else if(Role == "Admin")
            {
                _adminWindow.SetTrigger("Show");
            }
            else if(Role == "Teacher")
            {
                _teacherWindow.SetTrigger("Show");
            }
        }
        else
        {
            Debug.Log("Неверно введен логин/пароль");
        }
    }
}
