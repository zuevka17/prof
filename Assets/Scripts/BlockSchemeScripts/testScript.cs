using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    [SerializeField]private string FilledString;
    [SerializeField]private GameObject Start;
    public void ReturnString(GameObject BlockSchemeObject)
    {
        Debug.Log($"{BlockSchemeObject} connected to {BlockSchemeObject.GetComponent<BlockScheme>().block.ConnectedTo}");
        ReturnString(BlockSchemeObject.GetComponent<BlockScheme>().block.ConnectedTo);
    }
    public void SetFilledString()
    {
        ReturnString(Start);
    }
}
