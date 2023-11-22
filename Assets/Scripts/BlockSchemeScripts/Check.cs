using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check : MonoBehaviour
{
    [SerializeField]private GameObject nextTaskButton;
    private static bool check1(bool isControlTest)
    {
        Transform parentObj;

        if(isControlTest)
            parentObj = GameObject.Find("SaveControlTest").GetComponent<SaveBlockSchemes>().parentObject.transform;
        else
            parentObj = GameObject.Find("SaveTest").GetComponent<SaveBlockSchemes>().parentObject.transform;

        foreach (Transform child in parentObj)
        {
            BlockScheme.BlockSchemeComponent childBlock = child.GetComponent<BlockScheme>().block;
            if (childBlock.Type != "StartEnd(Clone)" && (childBlock.ConnectedFrom == null || childBlock.Type != "StartEnd(Clone)" && childBlock.ConnectedTo == null))
            {
                Debug.Log("��������. ���� 1 �� �������(������ ������ ��� ������).");
                return false;
            }
        }
        return true;
    }
    private static void check2(bool isControlTest)
    {
        int count = 0;

        List<string> studentList;
        List<string> teacherList = GameObject.Find("TaskFromDb").GetComponent<SelectRandomTask>().dbStrings;

        if(isControlTest)
            studentList = GameObject.Find("SaveControlTest").GetComponent<SaveBlockSchemes>().blockSchemasList;
        else
            studentList = GameObject.Find("SaveTest").GetComponent<SaveBlockSchemes>().blockSchemasList;

        List<string> temp = new List<string>();
        if(studentList.Count != teacherList.Count)
        {
            Debug.Log("������ ���������� ���� ����!");
            return;
        }

        for (int i = 0; i < teacherList.Count; i++)
        {
            if (teacherList[i] == studentList[i])
            {
                var gameObjectName = studentList[i].Substring(0, studentList[i].IndexOf(" "));
                GameObject currentGO = GameObject.Find(gameObjectName);

                currentGO.name = $"Checked{i}";
                temp.Add(currentGO.name);

                UnityEngine.UI.Image currentImage = currentGO.transform.Find("InputFieldOnBlockScheme").transform.Find("BlockScheme").gameObject.GetComponent<UnityEngine.UI.Image>();
                currentImage.color = new Color32(93, 226, 104, 255);
                Debug.Log($"�������� ��� ������� {i} �����");
                count++;
            }
            else
            {
                var gameObjectName = studentList[i].Substring(0, studentList[i].IndexOf(" "));
                GameObject currentGO = GameObject.Find(gameObjectName);

                currentGO.name = $"Checked{i}";
                temp.Add(currentGO.name);

                UnityEngine.UI.Image currentImage = currentGO.transform.Find("InputFieldOnBlockScheme").transform.Find("BlockScheme").gameObject.GetComponent<UnityEngine.UI.Image>();
                currentImage.color = new Color32(255, 0, 0, 255);

                Debug.Log($"�������� ��� ������� {i} �� �����");
            }
        }
        for (int i = 0; i < studentList.Count; i++)
        {
            GameObject.Find(temp[i]).name = studentList[i].Substring(0, studentList[i].IndexOf(" "));  
        }

        if (count == teacherList.Count)
        {
            Debug.Log("������� ������ �����!");
            if (isControlTest)
                GameObject.Find("CheckHolder").GetComponent<Check>().nextTaskButton.SetActive(true);
        }
        else
        {
            Debug.Log("��������. ���� 2 �� �������.");
        }   
    }
    public static void CheckForMistakes(bool isControlTest)
    {
        if(check1(isControlTest))
            check2(isControlTest);
    }

}
