using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class LogIn : MonoBehaviour
{
    [Header("DataBase Connect")]
    [SerializeField] private DbConnect _dataBaseConnection;

    [Header("Animator components")]
    [SerializeField] private Animator _adminWindow;
    [SerializeField] private Animator _mainWindow;
    [SerializeField] private Animator _studentWindow;
    [SerializeField] private Animator _teacherWindow;

    [Header("Input field components")]
    [SerializeField] private TMP_InputField _loginInput;
    [SerializeField] private TMP_InputField _passwordInput;  

    public void TryLogin()
    {
        DbConnect.User user = _dataBaseConnection.users.Where(u => u.Login == _loginInput.text && u.Password == _passwordInput.text).FirstOrDefault();
        
        if (user == null)
        {
            Debug.Log("Неверно введен логин или пароль!");
        }
        else
        {
            if (user.Role == "User")
            {
                _studentWindow.SetTrigger("Show");
            }
            else if(user.Role == "Admin")
            {
                _adminWindow.SetTrigger("Show");
            }
            else if(user.Role == "Teacher")
            {
                _teacherWindow.SetTrigger("Show");
            }
            _mainWindow.SetBool("IsHidden", true);
        }
    }
}
