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
    //дл€ тренировки
    public TMP_Text textField;
    public List<string> dbStrings = new List<string>();

    //ƒл€ контрольного тестировани€
    public TMP_Text textFieldControlTest;
    public List<List<string>> dbListsForControllTest = new List<List<string>>();
    public List<string> descriptions = new List<string>();

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
}
