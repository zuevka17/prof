using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ControlTest : MonoBehaviour
{
    private SelectRandomTask controlTestTask;
    private static int count = 0;
    [SerializeField]private GameObject workspace;
    void Start()
    {
        controlTestTask = GameObject.Find("TaskFromDb").GetComponent<SelectRandomTask>();
    }
    public void ControlTestSelectTask()
    {
        foreach (Transform child in workspace.transform)
        {
            Destroy(child.gameObject);
        }
        controlTestTask.dbStrings = controlTestTask.dbListsForControllTest[count];
        controlTestTask.textFieldControlTest.text = controlTestTask.descriptions[count];
        count++;
    }
    public void ControlTestEnd()
    {

    }
    private void Update()
    {
        if (count == controlTestTask.dbListsForControllTest.Count)
            Debug.Log("end of lits.");
    }
}
