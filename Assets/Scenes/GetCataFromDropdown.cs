using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCataFromDropdown : MonoBehaviour
{
    public TMP_Dropdown dropDown;

    public void GetData()
    {
        Debug.Log(dropDown.options[dropDown.value].text);
    }
}