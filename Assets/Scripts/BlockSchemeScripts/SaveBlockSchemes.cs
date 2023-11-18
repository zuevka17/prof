using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System;
using UnityEngine.Profiling;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditorInternal.VersionControl;
using TreeEditor;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SaveBlockSchemes : MonoBehaviour
{
    static public byte[] bytes;
    public GameObject parentObject;

    public List<string> blockSchemasList = new List<string>();
    public List<BlockScheme.BlockSchemeComponent> blockSchemas = new List<BlockScheme.BlockSchemeComponent>();
    public void SaveToList()
    {
        blockSchemasList.Clear();
        blockSchemas.Clear();

        foreach (Transform child in parentObject.transform)
        {
            BlockScheme.BlockSchemeComponent childBlock = child.GetComponent<BlockScheme>().block;
            if (childBlock.Type != "StartEnd(Clone)" && (childBlock.ConnectedFrom == null || childBlock.Type != "StartEnd(Clone)" && childBlock.ConnectedTo == null))
            {
                Debug.Log("Найдет объект без цепи.");
            }
            else
            {
                blockSchemas.Add(childBlock);
            }
        }

        blockSchemas = blockSchemas.OrderBy(x => x.OrderInHierarchy).ToList();

        foreach (var child in blockSchemas)
        {
            string type = child.Type;
            string text = child.TextOnBlockScheme;
            string connectedTo;
            if (child.ConnectedTo == null)
                connectedTo = "nothing";
            else
                connectedTo = child.ConnectedTo.name;   
            string connectedFrom;
            if (child.ConnectedFrom == null)
                connectedFrom = "nothing";
            else
                connectedFrom = child.ConnectedFrom.name;

            if (child.Type == "If(Clone)")

                blockSchemasList.Add($"{type} text: {text} connected to {connectedTo} and {child.ConnectedToSecond.name} connected from {connectedFrom}");
            else
                blockSchemasList.Add($"{type} text: {text} connected to {connectedTo} connected from {connectedFrom}");
        }
    }
    public static void ListToByteArray()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            bf.Serialize(ms, GameObject.Find("Save").GetComponent<SaveBlockSchemes>().blockSchemasList);
            bytes = ms.ToArray();
        }
    }
}