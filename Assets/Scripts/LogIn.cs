using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    [SerializeField] public string Login;
    [SerializeField] public string Password;
    [SerializeField] public string Role;


    [SerializeField] private Animator _adminWindow;
    [SerializeField] private Animator _mainWindow;
    [SerializeField] private Animator _studentWindow;

    [SerializeField] public GetCataFromInputField pass;
    [SerializeField] public GetCataFromInputField log;   

    public void TryLogin()
    {
        if (Login == pass.getText() && Password == log.getText())
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
        }
        else
        {
            Debug.Log("Неверно введен логин/пароль");
        }
    }
}
