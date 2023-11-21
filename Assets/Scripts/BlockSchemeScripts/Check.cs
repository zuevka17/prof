using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check : MonoBehaviour
{

    private static bool check1()
    {
        foreach (Transform child in GameObject.Find("SaveTest").GetComponent<SaveBlockSchemes>().parentObject.transform)
        {
            BlockScheme.BlockSchemeComponent childBlock = child.GetComponent<BlockScheme>().block;
            if (childBlock.Type != "StartEnd(Clone)" && (childBlock.ConnectedFrom == null || childBlock.Type != "StartEnd(Clone)" && childBlock.ConnectedTo == null))
            {
                Debug.Log("Проверка. Этап 1 НЕ пройден(найден объект без связей).");
                return false;
            }
        }
        return true;
    }
    private static void check2()
    {
        int count = 0;

        List<string> studentList = GameObject.Find("SaveTest").GetComponent<SaveBlockSchemes>().blockSchemasList;
        List<string> teacherList = GameObject.Find("TaskFromDb").GetComponent<SelectRandomTask>().dbStrings;

        List<string> temp = new List<string>();
        if(studentList.Count != teacherList.Count)
        {
            Debug.Log("Разное количество блок схем!");
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
                Debug.Log($"Элементы под номером {i} равны");
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

                Debug.Log($"Элементы под номером {i} НЕ равны");
            }
        }
        for (int i = 0; i < studentList.Count; i++)
        {
            GameObject.Find(temp[i]).name = studentList[i].Substring(0, studentList[i].IndexOf(" "));  
        }

        if (count == teacherList.Count)
        {
            Debug.Log("Задание решено верно!");
        }
        else
        {
            Debug.Log("Проверка. Этап 2 НЕ пройден.");
        }
    }
    public static void CheckForMistakes()
    {
        if(check1())
            check2();
    }

}
