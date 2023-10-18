using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField] public List<string> TaskString = new List<string>();

    [SerializeField] public List<string> UserString;
    private void Start()
    {
        TaskString = new List<string>()
        {
            "Start(Clone) connected to If(Clone)",
            "If(Clone) connected to For(Clone)",
            "123"
        };
    }
    void Update()
    {
        if (TaskString.SequenceEqual(UserString))
        {
            Debug.Log("EQUAL");
        }
    }

    public void AddToUserList(GameObject gameObj)
    {
        UserString.Add($"{gameObj.name}");
    }
    public void AddToTaskList(string FirstValue, string SecondValue)
    {
        TaskString.Add($"{FirstValue} connected to {SecondValue}");
    }
    public void DeleteElement(GameObject gameObj)
    {
       UserString.RemoveAll(item => item == gameObj.name);
    }

}
