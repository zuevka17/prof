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
using System;
using UnityEngine.Profiling;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditorInternal.VersionControl;
using TreeEditor;
using System.Xml.Linq;

public class SaveBlockSchemes : MonoBehaviour
{
    static public byte[] bytes;
    public GameObject parentObject;

    public List<string> blockSchemasList = new List<string>();
    public void SaveToList()
    {
        blockSchemasList.Clear();
        foreach (Transform child in parentObject.transform)
        {
            BlockScheme.BlockSchemeComponent block = child.GetComponent<BlockScheme>().block;
            string type = block.Type;
            string text = block.TextOnBlockScheme;
            string connectedTo;
            if (block.ConnectedTo == null)
                connectedTo = "nothing";
            else
                connectedTo = block.ConnectedTo.name;
            string connectedFrom;
            if (block.ConnectedFrom == null)
                connectedFrom = "nothing";
            else
                connectedFrom = block.ConnectedFrom.name;

            if (child.GetComponent<BlockScheme>().block.Type == "If(Clone)")

                blockSchemasList.Add($"{type} text: {text} connected to {connectedTo} and {block.ConnectedToSecond.name} connected from {connectedFrom}");
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