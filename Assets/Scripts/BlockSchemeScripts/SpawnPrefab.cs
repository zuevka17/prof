using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    //Поле Prefab в котором указывается объект который нужно создать. В поле ParentObject в котором указывается объект-родитель
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject ParentObject;
    public void SpawnPref()
    {
        //Находим позицию мыши на экране ScreenToWorldPoint - преобразует точку из экранного пространства в мировое пространство
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 SpawnPos = new Vector3(MousePosition.x, MousePosition.y, 0f);
        //Метод Instantiate создаёт объект на сцене
        Instantiate(Prefab, SpawnPos, quaternion.identity, ParentObject.transform);
    }
}
