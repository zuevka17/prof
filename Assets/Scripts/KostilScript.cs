using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KostilScript : MonoBehaviour
{
    public GameObject gameObject;
    public void RememberGameObjec(GameObject gameObj)
    {
        gameObject = gameObj;
        Debug.Log(gameObject.name);
    }
    public void Connect(GameObject gameObjectToConnect)
    {
        gameObject.GetComponent<LineDrawer>().ConnectToBlockScheme(gameObjectToConnect);
    }
}
