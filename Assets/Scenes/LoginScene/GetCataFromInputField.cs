using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCataFromInputField : MonoBehaviour
{
    public GameObject inputField;
    private string text;

    public void getValue()
    {
        text = inputField.GetComponent<TMP_InputField>().text;
        Debug.Log(text);
    }
    public string getText()
    {
        return text;
    }

}
