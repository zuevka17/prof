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
        public string TextOnBlockScheme;

        public string BlockSchemeName;
        public GameObject ConnectedTo;
        public GameObject ConnectedFrom;
        public int OrderInHierarchy;

        public bool IsConnected = false;

        public GameObject ConnectionPos;
        public GameObject ConnectionFromPos;

        public BlockSchemeComponent(string BlockSchemeName, int OrderInHierarchy, GameObject ConnectionPos, GameObject ConnectionFromPos)
        {
            this.BlockSchemeName = BlockSchemeName;
            this.OrderInHierarchy = OrderInHierarchy;
            this.ConnectionPos = ConnectionPos;
            this.ConnectionFromPos = ConnectionFromPos;
        }
        public BlockSchemeComponent()
        {
            
        }

    }
    public static int CountInBlockSchemeHierarcy = 0;
    private static GameObject _previousGameObject;
    [SerializeField] public BlockSchemeComponent block;

    public LineRenderer LineRend;
    private Vector2 _mousePos;
    public Vector2 LineRendStartPos;

    private bool _canDrawLine = false;

    public GameObject finpos;


    void Awake()
    {
        //Создание экземпляра класса
        block = new BlockSchemeComponent(gameObject.name, CountInBlockSchemeHierarcy, transform.Find("ConnectionPos").gameObject, transform.Find("ConnectionFromPos").gameObject);
        if (block.OrderInHierarchy == 0)
        {
            block.ConnectionPos.SetActive(false);
        }

        //Нахождение компонента LineRenderer, максимальное количество точек 0
        LineRend = GetComponent<LineRenderer>();
        LineRend.positionCount = 2;

        CountInBlockSchemeHierarcy++;
    }
    void Update()
    {
        //Построение линий
        if (Input.GetMouseButton(0) && _canDrawLine && !block.IsConnected)
        {
            LineRendStartPos = block.ConnectionFromPos.transform.position;
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            LineRend.SetPosition(0, new Vector2(LineRendStartPos.x, LineRendStartPos.y));
            LineRend.SetPosition(1, new Vector2(_mousePos.x, _mousePos.y));
            block.ConnectionPos.SetActive(false);
        }
        //Удаление линии при отпускании мыши
        if (Input.GetMouseButtonUp(0))
        {
            LineRend.SetPosition(0, new Vector2(LineRendStartPos.x, LineRendStartPos.y));
            LineRend.SetPosition(1, new Vector2(LineRendStartPos.x, LineRendStartPos.y));

            _canDrawLine = false;

            if (!(block.OrderInHierarchy == 0))
                block.ConnectionPos.SetActive(true);
        }
        //Установка значений 0 и 1 позиции линии если два объекта соеденены
        if (block.IsConnected)
        {
            LineRend.SetPosition(0, block.ConnectionFromPos.transform.position);
            LineRend.SetPosition(1, finpos.transform.position);
        }
    }
    //присвоение переменной _canDrawLine значения true
    public void SetCanDrawToTrue()
    {
        _canDrawLine = true;
    }
    //присвоение переменной _canDrawLine значения false
    public void SetCanDrawToFalse()
    {
        if (Input.GetMouseButton(0))
        {

        }
        else
        {
            _canDrawLine = false;
        }
    }
    //Соединение блок схем
    private void ConnectToBlockScheme(GameObject gameObj)
    {
        if (_canDrawLine && !block.IsConnected && gameObj.GetComponent<BlockScheme>().block.ConnectedFrom == null)
        {
            //Установка конечной позиции LineRenderer-а на ConnectionPos второго объекта
            LineRend.SetPosition(1, gameObj.GetComponent<BlockScheme>().block.ConnectionPos.transform.position);
            finpos = gameObj.GetComponent<BlockScheme>().block.ConnectionPos;

            gameObj.GetComponent<BlockScheme>().block.ConnectedFrom = gameObject;
            gameObject.GetComponent<BlockScheme>().block.ConnectedTo = gameObj;
            gameObject.GetComponent<BlockScheme>().block.OrderInHierarchy = this.block.OrderInHierarchy++;

            _canDrawLine = false;
            block.IsConnected = true;
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

    //-------------------------------------------------------------------------------------------------------------------------
    
    //Добавление текста к объекту класса
    public void AddText()
    {
        block.TextOnBlockScheme = transform.Find("InputFieldOnBlockScheme").gameObject.GetComponent<TMP_InputField>().text;
    }
}
