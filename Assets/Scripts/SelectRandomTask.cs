using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Unity.VisualScripting;
using System.Linq;

public class SelectRandomTask : MonoBehaviour
{
    [SerializeField] public TMP_Text textField;
    public List<string> dbStrings = new List<string>();

    public static List<string> ByteArrayToObject(byte[] bytes)
    {
        using (var memStream = new MemoryStream())
        {
            var binForm = new BinaryFormatter();
            memStream.Write(bytes, 0, bytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            return (List<string>)binForm.Deserialize(memStream);
        }
    }
    void Update()
    {
        if (Enumerable.SequenceEqual(GameObject.Find("SaveTest").GetComponent<SaveBlockSchemes>().blockSchemasList, dbStrings))
        {
            Debug.Log("EQUAL!!!");
        }
    }
}
