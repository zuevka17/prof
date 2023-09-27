using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsersTable : MonoBehaviour
{
    [Header("DataBase Connect")]
    [SerializeField] private DbConnect _dataBaseConnection;

    [Header("Text Field")]
    [SerializeField] private TMP_Text _loginField;
    [SerializeField] private TMP_Text _roleField;

    public void UpdateInfo()
    {
        _loginField.text = "";
        _roleField.text = "";

        foreach (var item in _dataBaseConnection.users)
        {
            _loginField.text += $"{item.Login}\n";
            _roleField.text  += $"{item.Role}\n";
        }
    }
    void Start()
    {
        UpdateInfo();
    }

}
