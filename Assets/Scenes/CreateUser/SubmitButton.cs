using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SubmitButton : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    public void ChangeScene()
    {
        if (dropDown.options[dropDown.value].text != "Выбрать")
        {
            SceneManager.LoadScene("AdministratorWindow");
        }
        else 
        {
            Debug.Log("Не выбрана роль");
        }
    }
}
