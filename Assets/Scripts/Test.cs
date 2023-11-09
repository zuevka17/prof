using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using System;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField] public string CreatedString = String.Empty; 

    public List<GameObject> TaskString;

    public List<GameObject> UserString;

    void Start()
    {
        TaskString = new List<GameObject>();
        UserString = new List<GameObject>();
    }
    void Update()
    {
        if (TaskString.SequenceEqual(UserString))
        {
            Debug.Log("EQUAL");
        }
    }

    public void AddToList(GameObject gameObj)
    {

        if (GameObject.Find("DbConnect").GetComponent<DbConnect>().currentUser.Role == "Teacher")
        {
            if (TaskString.Any(x => x == null))
            {
                var firstNullValue = TaskString.FirstOrDefault(x => x == null);
                TaskString[TaskString.IndexOf(firstNullValue)] = gameObj;
            }
            else
            {
                TaskString.Add(gameObj);
            }
        }
        else
        {
            UserString.Add(gameObj);
        }
    }

    public void DeleteElement(GameObject gameObj)
    {
        if (GameObject.Find("DbConnect").GetComponent<DbConnect>().currentUser.Role == "Teacher")
        {
            var firstGameObjectValue = TaskString.FirstOrDefault(x => x == gameObj);
            if (firstGameObjectValue != null)
            {
                if (TaskString.IndexOf(firstGameObjectValue) == 0)
                {
                    TaskString.Where(x => x == gameObj).ToList().ForEach(x => x = null);
                }
                else
                {
                    TaskString[TaskString.IndexOf(firstGameObjectValue) - 1] = null;
                    TaskString[TaskString.IndexOf(firstGameObjectValue)] = null;
                }
            }
        }
        else
        {
            UserString.Where(x => x == gameObj).ToList().ForEach(x => x = null);
        }
    }
    public void Save()
    {
        CreatedString = String.Empty;
        foreach (var item in TaskString)
        {
            CreatedString += item.name + item.GetComponent<TMP_InputField>().text;
        }
    }
}
