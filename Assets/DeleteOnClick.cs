using System;
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
            try
            {
                LineDrawer ld= gameObject.GetComponentInParent<LineDrawer>().previousConnection.GetComponent<LineDrawer>();
                ld.isConnected = false;
                ld.LineRend.SetPosition(1, new Vector2 (ld.startPos.transform.position.x, ld.startPos.transform.position.y));
            }
            catch (Exception ex)
            {
                
            }

            Debug.Log(gameObject.transform.parent.name);
            _test.DeleteElement(gameObject.transform.parent.gameObject);

            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}