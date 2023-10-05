using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;


public class DoubleTapInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private int clickCounts = 0;

    public void Activate()
    {
        if (clickCounts >= 2)
        {
            clickCounts = 0;
        }
        if (clickCounts < 2)
        {
            clickCounts++;
            if (clickCounts == 2)
            {
                _inputField.ActivateInputField();
            }
        }

    }
}
