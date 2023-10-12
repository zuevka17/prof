using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _myPrefab;
    [SerializeField] private GameObject _prefabParent;

    private Vector3 _mousePos;

    public void UsePrefab()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouse = new Vector3 (_mousePos.x, _mousePos.y, 0f);
        Instantiate(_myPrefab, mouse, Quaternion.identity, _prefabParent.transform);
    }
}
