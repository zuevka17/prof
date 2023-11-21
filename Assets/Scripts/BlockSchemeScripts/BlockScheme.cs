using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockScheme : MonoBehaviour
{
    [System.Serializable]
    public class BlockSchemeComponent
    {
        public string Type;
        public string TextOnBlockScheme;

        public string BlockSchemeName;
        public GameObject ConnectedTo;
        public GameObject ConnectedFrom;
        public int OrderInHierarchy;

        public bool IsConnected = false;

        public GameObject ConnectionPos;
        public GameObject ConnectionFromPos;
        //Необязательное поле класса ConnectionPosSecond
#nullable enable
        public GameObject? ConnectionFromPosSecond;
        public GameObject? ConnectedToSecond;
        public bool? IsSecondConnected = false;
#nullable disable
        public bool IsConnectedFormSecondPoint = false;
        //Конструктор класса
        public BlockSchemeComponent(string BlockSchemeName, int OrderInHierarchy, GameObject ConnectionPos, GameObject ConnectionFromPos, string Type)
        {
            this.BlockSchemeName = BlockSchemeName;
            this.OrderInHierarchy = OrderInHierarchy;
            this.ConnectionPos = ConnectionPos;
            this.ConnectionFromPos = ConnectionFromPos;
            this.Type = Type;
        }
    }
    public static int CountInBlockSchemeHierarcy = 0;
    private static GameObject _previousGameObject;
    [SerializeField] public BlockSchemeComponent block;

    public LineRenderer LineRend;
#nullable enable
    public LineRenderer? LineRendSecond;
    public GameObject FinposSecond;
#nullable disable
    private Vector2 _mousePos;
    public Vector2 LineRendStartPos;
    public Vector2 LineRendStartPosSecond;

    private bool _canDrawLine = false;
    private bool _canDrawSecondLine = false;

    public GameObject Finpos;


    void Awake()
    {
        //Создание экземпляра класса
        block = new BlockSchemeComponent(gameObject.name, CountInBlockSchemeHierarcy, transform.Find("ConnectionPos").gameObject, transform.Find("ConnectionFromPos").gameObject, gameObject.name);
        //Если у блок схемы есть две точки из которых может выходить линия
        if (block.Type == "If(Clone)")
        {
            block.ConnectionFromPosSecond = transform.Find("ConnectionFromPosSecond").gameObject;
        }
        //Убераем connectionpos если это первый объет на сцене
        if (block.OrderInHierarchy == 0)
        {
            block.ConnectionPos.SetActive(false);
        }
        //Нахождение компонента LineRenderer, максимальное количество точек 
        LineRend = transform.Find("ConnectionFromPos").gameObject.GetComponent<LineRenderer>();
        LineRend.positionCount = 2;

        if (block.Type == "If(Clone)")
        {
            LineRendSecond = transform.Find("ConnectionFromPosSecond").gameObject.GetComponent<LineRenderer>();
            LineRendSecond.positionCount = 2;
        }

        CountInBlockSchemeHierarcy++;
    }
    void Update()
    {
        //Построение линий
        if (Input.GetMouseButton(0) && _canDrawLine && !block.IsConnected)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LineRendStartPos = block.ConnectionFromPos.transform.position;

            LineRend.SetPosition(0, new Vector2(LineRendStartPos.x, LineRendStartPos.y));
            LineRend.SetPosition(1, new Vector2(_mousePos.x, _mousePos.y));

            block.ConnectionPos.SetActive(false);
        }
        if (Input.GetMouseButton(0) && _canDrawSecondLine && (bool)!block.IsSecondConnected)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LineRendStartPosSecond = block.ConnectionFromPosSecond.transform.position;

            LineRendSecond.SetPosition(0, new Vector2(LineRendStartPosSecond.x, LineRendStartPosSecond.y));
            LineRendSecond.SetPosition(1, new Vector2(_mousePos.x, _mousePos.y));

            block.ConnectionPos.SetActive(false);
        }
        //Удаление линии при отпускании мыши
        if (Input.GetMouseButtonUp(0))
        {
            if (_canDrawLine)
            {
                LineRend.SetPosition(0, new Vector2(LineRendStartPos.x, LineRendStartPos.y));
                LineRend.SetPosition(1, new Vector2(LineRendStartPos.x, LineRendStartPos.y));
                _canDrawLine = false;
            }
            if (LineRendSecond != null && _canDrawSecondLine)
            {
                LineRendSecond.SetPosition(0, new Vector2(LineRendStartPosSecond.x, LineRendStartPosSecond.y));
                LineRendSecond.SetPosition(1, new Vector2(LineRendStartPosSecond.x, LineRendStartPosSecond.y));
                _canDrawSecondLine = false;
            }

            if (!(block.OrderInHierarchy == 0))
                block.ConnectionPos.SetActive(true);
        }
        //Установка значений 0 и 1 позиции линии если два объекта соеденены
        if (block.IsConnected)
        {
            LineRend.SetPosition(0, block.ConnectionFromPos.transform.position);
            LineRend.SetPosition(1, Finpos.transform.position);
        }
        if ((bool)block.IsSecondConnected)
        {
            LineRendSecond.SetPosition(0, block.ConnectionFromPosSecond.transform.position);
            LineRendSecond.SetPosition(1, FinposSecond.transform.position);
        }
    }
    //присвоение переменной _canDrawLine значения true
    public void SetCanDrawToTrue(bool isSecondLine)
    {
        if (!isSecondLine)
        {
            _canDrawLine = true;
        }
        else
        {
            _canDrawSecondLine = true;
        }
    }
    //присвоение переменной _canDrawLine значения false
    public void SetCanDrawToFalse(bool isSecondLine)
    {
        if (Input.GetMouseButton(0))
        {

        }
        else
        {
            if (!isSecondLine)
            {
                _canDrawLine = false;
            }
            else
            {
                _canDrawSecondLine = false;
            }
        }
    }
    //Соединение блок схем
    private void ConnectToBlockScheme(GameObject gameObj)
    {
        if (_canDrawLine && !block.IsConnected && gameObj.GetComponent<BlockScheme>().block.ConnectedFrom == null)
        {
            //Установка конечной позиции LineRenderer-а на ConnectionPos второго объекта
            LineRend.SetPosition(1, gameObj.GetComponent<BlockScheme>().block.ConnectionPos.transform.position);
            Finpos = gameObj.GetComponent<BlockScheme>().block.ConnectionPos;

            gameObj.GetComponent<BlockScheme>().block.ConnectedFrom = gameObject;
            gameObj.GetComponent<BlockScheme>().block.OrderInHierarchy = gameObject.GetComponent<BlockScheme>().block.OrderInHierarchy + 1;
            gameObject.GetComponent<BlockScheme>().block.ConnectedTo = gameObj;

            _canDrawLine = false;
            block.IsConnected = true;
        }
        if (_canDrawSecondLine && (bool)!block.IsSecondConnected && gameObj.GetComponent<BlockScheme>().block.ConnectedFrom == null)
        {
            //Установка конечной позиции LineRenderer-а на ConnectionPos второго объекта
            LineRendSecond.SetPosition(1, gameObj.GetComponent<BlockScheme>().block.ConnectionPos.transform.position);
            FinposSecond = gameObj.GetComponent<BlockScheme>().block.ConnectionPos;

            gameObj.GetComponent<BlockScheme>().block.ConnectedFrom = gameObject;
            gameObj.GetComponent<BlockScheme>().block.OrderInHierarchy = gameObject.GetComponent<BlockScheme>().block.OrderInHierarchy + 1;
            gameObject.GetComponent<BlockScheme>().block.ConnectedToSecond = gameObj;

            _canDrawSecondLine = false;
            block.IsSecondConnected = true;
            gameObj.GetComponent<BlockScheme>().block.IsConnectedFormSecondPoint = true;
        }
    }
    public static void SetPreviousGameObject(GameObject gameObj)
    {
        _previousGameObject = gameObj;
    }
    public void CreateConnection(GameObject gameObj)
    {
        if (_previousGameObject != null)
        {
            _previousGameObject.GetComponent<BlockScheme>().ConnectToBlockScheme(gameObj);
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------

    //Добавление текста к объекту класса
    public void AddText()
    {
        block.TextOnBlockScheme = transform.Find("InputFieldOnBlockScheme").gameObject.GetComponent<TMP_InputField>().text;
    }
}
