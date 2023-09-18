using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    public string login;
    public string password;

    public GetCataFromInputField pass;
    public GetCataFromInputField log;   

    public void TryLogin()
    {
        if (login == pass.getText() && password == log.getText())
        {
            Debug.Log("aaaaaaaa");
            SceneManager.LoadScene("AdministratorWindow");
        }
        else
        {
            Debug.Log("Неверно введен логин/пароль");
        }
    }
}
