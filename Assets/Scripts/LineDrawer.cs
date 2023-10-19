using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using Unity.VisualScripting;

public class LineDrawer : MonoBehaviour
{
    public GameObject previousConnection;

    private Test _test;
    public LineRenderer LineRend;
    private Vector2 _mousePos;
    private Vector2 _startMousePos;

    [SerializeField] public GameObject connectPos;
    [SerializeField] public GameObject startPos;
    [SerializeField] public GameObject finishPos;

    private bool canDrawLine = false;
    public bool isConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        _test = GameObject.Find("TestWithLists").GetComponent<Test>();
        LineRend = GetComponent<LineRenderer>();
        LineRend.positionCount = 2;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && canDrawLine && !isConnected)
        {
            _startMousePos = startPos.transform.position;
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LineRend.SetPosition(0, new Vector2(_startMousePos.x, _startMousePos.y));
            LineRend.SetPosition(1, new Vector2(_mousePos.x, _mousePos.y));
            connectPos.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            LineRend.SetPosition(0, new Vector2(_startMousePos.x, _startMousePos.y));
            LineRend.SetPosition(1, new Vector2(_startMousePos.x, _startMousePos.y));

            canDrawLine = false;

            connectPos.SetActive(true);
        }

        if (isConnected)
        {
            LineRend.SetPosition(0, startPos.transform.position);
            LineRend.SetPosition(1, finishPos.transform.position);
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
        if (canDrawLine && !isConnected)
        {
            gameObj.GetComponentInParent<LineDrawer>().previousConnection = gameObject;

            LineRend.SetPosition(1, gameObj.transform.position);
            finishPos = gameObj;
            canDrawLine = false;
            isConnected = true;

            _test.AddToList(gameObject);
        }
    }
}
