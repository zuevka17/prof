using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnClick : MonoBehaviour
{
    private Test _test;
    private bool _isSelected = false;

    private void Start()
    {
        _test = GameObject.Find("TestWithLists").GetComponent<Test>();
    }
    public void MouseOnGameObeject()
    {
        _isSelected = true;
    }
    public void MouseNotOnGameObeject()
    {
        _isSelected = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && _isSelected)
        {
            gameObject.GetComponentInParent<LineDrawer>().previousConnection.GetComponent<LineDrawer>().isConnected = false;

            Debug.Log(gameObject.transform.parent.name);
            _test.DeleteElement(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}