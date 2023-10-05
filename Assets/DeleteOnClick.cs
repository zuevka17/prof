using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnClick : MonoBehaviour
{
    private bool _isSelected = false;

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
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}