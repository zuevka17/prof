using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check : MonoBehaviour
{
    public static void CheckForMistakes()
    {
        List<string> studentList = GameObject.Find("SaveTest").GetComponent<SaveBlockSchemes>().blockSchemasList;
        List<string> teacherList = GameObject.Find("TaskFromDb").GetComponent<SelectRandomTask>().dbStrings;

        for(int i = 0; i < teacherList.Count; i++)
        {
            if (teacherList[i] == studentList[i])
            {
                var gameObjectName = studentList[i].Substring(0, studentList[i].IndexOf(" "));
                GameObject currentGO = GameObject.Find(gameObjectName);
                UnityEngine.UI.Image currentImage = currentGO.transform.Find("InputFieldOnBlockScheme").transform.Find("BlockScheme").gameObject.GetComponent<UnityEngine.UI.Image>();
                currentImage.color = new Color32(93, 226, 104, 255);
                Debug.Log($"Ёлементы под номером {i} равны");
            }
            else
            {
                Debug.Log($"Ёлементы под номером {i} Ќ≈ равны");
            }
        }
    }

}
