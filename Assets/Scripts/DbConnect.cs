using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;
using System;

public class DbConnect : MonoBehaviour
{
    string con = @"server=192.168.0.1\SQLEXPRESS;user=is51_0;password=12345678Aa;trusted_connection=false;TrustServerCertificate=true;database=Unity";

    List<User> users = new List<User>();

    void Start()
    {
        users = ConnectToDB();
    }

    void OnGUI()
    {
        int i = 0;
        foreach (User user in users)
        {
            Rect position = new Rect(i * 20, i * 20, 100, 20);
            GUI.Label(position, user.Login);
            i++;
        }
    }
    List<User> ConnectToDB()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                Debug.Log("Connection is open.");
                string sqlCom = "SELECT id, [Login], Password, [Role]\r\nFROM Unity.dbo.Users;";
                using (SqlCommand command = new SqlCommand(sqlCom, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) & !reader.IsDBNull(1) & !reader.IsDBNull(2) & !reader.IsDBNull(3))
                            {
                                string userLogin = reader.GetString(1);
                                Debug.Log(userLogin);
                                string userPassword = reader.GetString(2);
                                Debug.Log(userPassword);
                                string userRole = reader.GetString(3);
                                Debug.Log(userRole);

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
