using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;
using System;
using TMPro;

public class DbConnect : MonoBehaviour
{
    private string con = @"server=192.168.0.1\SQLEXPRESS;user=is51_0;password=12345678Aa;trusted_connection=false;TrustServerCertificate=true;database=Unity";

    public List<User> users = new List<User>();

    [Header("Create user input fields")]
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_Dropdown _selectRole;

    void Start()
    {
        users = ConnectToDB();
    }

    List<User> ConnectToDB()
    {
        users.Clear();

        try
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                Debug.Log("Updating users list...");
                string SqlCom = "SELECT id, [Login], Password, [Role]\r\nFROM Unity.dbo.Users;";
                using (SqlCommand command = new SqlCommand(SqlCom, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) & !reader.IsDBNull(1) & !reader.IsDBNull(2) & !reader.IsDBNull(3))
                            {
                                string userLogin = reader.GetString(1);
                                string userPassword = reader.GetString(2);
                                string userRole = reader.GetString(3);

                                User user = new User(userLogin, userPassword, userRole);
                                users.Add(user);
                            }
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }
        return users;
    }

    public void CreateUser()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                Debug.Log("Inserting data into database...");
                string SqlCom = "INSERT INTO Unity.dbo.Users (Login, Password, Role)\r\nVALUES(@login, @password, @role)";
                using (SqlCommand command = new SqlCommand(SqlCom, connection))
                {
                    command.Parameters.Add("@login", SqlDbType.VarChar).Value = _login.text;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = _password.text;
                    command.Parameters.Add("@role", SqlDbType.VarChar).Value = _selectRole.options[_selectRole.value].text;

                    int rowsAdded = command.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        Debug.Log("Row inserted!!");
                    else
                        Debug.Log("No row inserted");

                    connection.Close();
;                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }
        Start();
    }

    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(string Login, string Password, string Role)
        {
            this.Login = Login;
            this.Password = Password;
            this.Role = Role;
        }
        public override string ToString()
        {
            return "Person: " + this.Login + " Password: " + this.Password + " Role: " + this.Role;
        }
    }

}
