using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class LineDrawer : MonoBehaviour
{

    private LineRenderer _lineRend;
    private Vector2 _mousePos;
    private Vector2 _startMousePos;

    public GameObject connectPos;
    public GameObject startPos;
    private GameObject finishPos;

    private bool canDrawLine = false;
    private bool isConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        _lineRend = GetComponent<LineRenderer>();
        _lineRend.positionCount = 2;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && canDrawLine && !isConnected)
        {
            _startMousePos = startPos.transform.position;
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _lineRend.SetPosition(0, new Vector2(_startMousePos.x, _startMousePos.y));
            _lineRend.SetPosition(1, new Vector2(_mousePos.x, _mousePos.y));
            connectPos.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _lineRend.SetPosition(0, new Vector2(_startMousePos.x, _startMousePos.y));
            _lineRend.SetPosition(1, new Vector2(_startMousePos.x, _startMousePos.y));

            canDrawLine = false;

            connectPos.SetActive(true);
        }

        if (isConnected)
        {
            _lineRend.SetPosition(0, startPos.transform.position);
            _lineRend.SetPosition(1, finishPos.transform.position);
        }
    }
    public void SetCanDrawToTrue()
    {
        canDrawLine = true;
    }
    public void SetCanDrawToFalse()
    {
        if (Input.GetMouseButton(0))
        {
            
        }
        else
        {
            canDrawLine = false;
        }
    }
    public void ConnectToBlockScheme(GameObject gameObj)
    {
        if (canDrawLine)
        {
            _lineRend.SetPosition(1, gameObj.transform.position);
            finishPos = gameObj;
            canDrawLine = false;
            isConnected = true;
        }
    }
}
    