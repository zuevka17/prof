using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _myPrefab;
    [SerializeField] private GameObject _prefabParent;

    public void UsePrefab()
    {
        Vector3 mouse = Input.mousePosition;
        Instantiate(_myPrefab, mouse, Quaternion.identity, _prefabParent.transform);
    }
}
