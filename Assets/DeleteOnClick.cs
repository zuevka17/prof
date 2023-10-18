using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnClick : MonoBehaviour
{
    private Test _test;
    private bool _isSelected = false;

    private void Start()
    {
        _test = GameObject.Find("Test").GetComponent<Test>();
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
            Debug.Log(gameObject.name);
            _test.DeleteElement(gameObject);
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}