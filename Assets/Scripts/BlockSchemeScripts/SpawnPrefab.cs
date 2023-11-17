using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject ParentObject;
    public void SpawnPref()
    {
        Vector3 SpawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 MousePosition = new Vector3(SpawnPos.x, SpawnPos.y, 0f);
        Instantiate(Prefab, MousePosition, quaternion.identity, ParentObject.transform);
    }
}
