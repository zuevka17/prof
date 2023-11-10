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

public class SaveBlockSchemes : MonoBehaviour
{
    static byte[] data;
    public GameObject parentObject;

    [SerializeField]public List<BlockScheme.BlockSchemeComponent> testList = new List<BlockScheme.BlockSchemeComponent>();
    public static List<BlockScheme.BlockSchemeComponent> blockSchemasList = new List<BlockScheme.BlockSchemeComponent>();
    public void SaveToList()
    {
        blockSchemasList.Clear();
        foreach (Transform child in parentObject.transform)
        {
            blockSchemasList.Add(child.GetComponent<BlockScheme>().block);
        }
    }
    public static byte[] SerializeList()
    {
        byte[] data;
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, blockSchemasList);
            data = stream.ToArray();
        }
        return data;
    }
    public static void Deserialize()
    {
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream(data))
        {
            blockSchemasList = (List<BlockScheme.BlockSchemeComponent>)formatter.Deserialize(stream);
        }
    }
}
