using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test : MonoBehaviour
{

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
        if(GameObject.Find("DbConnect").GetComponent<DbConnect>().currentUser.Role == "Teacher")
        {
            TaskString.Add(gameObj);
        }
        else
        {
            UserString.Add(gameObj);
        }
    }

    public void DeleteElement(GameObject gameObj)
    {
        UserString.RemoveAll(item => item == gameObj);
    }

}
