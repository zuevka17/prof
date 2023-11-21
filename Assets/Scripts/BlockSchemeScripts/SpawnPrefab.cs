using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    //���� Prefab � ������� ����������� ������ ������� ����� �������. � ���� ParentObject � ������� ����������� ������-��������
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject ParentObject;
    public void SpawnPref()
    {
        //������� ������� ���� �� ������ ScreenToWorldPoint - ����������� ����� �� ��������� ������������ � ������� ������������
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 SpawnPos = new Vector3(MousePosition.x, MousePosition.y, 0f);
        //����� Instantiate ������ ������ �� �����
        Instantiate(Prefab, SpawnPos, quaternion.identity, ParentObject.transform);
    }
}
