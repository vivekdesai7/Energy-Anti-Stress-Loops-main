using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnNodeClick : MonoBehaviour
{
    void OnMouseUp()
    {
        OnButtonClick();
    }

    private void OnButtonClick()
    {
        // Perform your button action here
        Debug.Log("Sprite button clicked!");
    }
}
