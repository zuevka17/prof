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

public class SaveBlockSchemes : MonoBehaviour
{
    public GameObject parentObject;

    [SerializeField]public List<BlockScheme.BlockSchemeComponent> testList = new List<BlockScheme.BlockSchemeComponent>();
    public static List<BlockScheme.BlockSchemeComponent> blockSchemasList = new List<BlockScheme.BlockSchemeComponent>();

    public static string serializeList;
    public void SaveToList()
    {
        blockSchemasList.Clear();
        foreach (Transform child in parentObject.transform)
        {
            blockSchemasList.Add(child.GetComponent<BlockScheme>().block);
        }
    }
    public static string SerializeList()
    {
        serializeList = JsonConvert.SerializeObject(blockSchemasList);
        return serializeList;
    }
    public static void Deserialize()
    {
        GameObject.Find("Save").GetComponent<SaveBlockSchemes>().testList = (List<BlockScheme.BlockSchemeComponent>)JsonConvert.DeserializeObject(serializeList);
    }
}
