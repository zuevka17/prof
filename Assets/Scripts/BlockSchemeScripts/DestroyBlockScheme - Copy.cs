using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyBlockScheme : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (gameObject.GetComponent<BlockScheme>().block.ConnectedFrom != null)
            {
                gameObject.GetComponent<BlockScheme>().block.ConnectedFrom.GetComponent<BlockScheme>().block.IsConnected = false;
                gameObject.GetComponent<BlockScheme>().block.ConnectedFrom.GetComponent<BlockScheme>().LineRend.SetPosition(1, gameObject.GetComponent<BlockScheme>().block.ConnectedFrom.GetComponent<BlockScheme>().LineRendStartPos);
            }
            Destroy(gameObject);
            BlockScheme.CountInBlockSchemeHierarcy--;
        }
    }
}
