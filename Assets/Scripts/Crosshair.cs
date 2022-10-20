using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{   
    [SerializeField]
    protected RectTransform crosshair;
    // Update is called once per frame
    void Update()
    {
        //mousePos <- get mouse position
        //set the crosshair to mouse position
        //if mouse points is on the screen
        // a. make mouse pointer invisible
        // b. make crosshair visible. 
        //else:
        // a. make mouse pointer visible
        // b. make crosshair invisible
        Vector2 mousePos = Input.mousePosition;
        crosshair.position = mousePos;
        if(mousePos.x > 0 && mousePos.y > 0 && Screen.width > mousePos.x && Screen.height > mousePos.y)
        {
            Cursor.visible = false;
            crosshair.gameObject.SetActive(true);
        }
        else
        {
            Cursor.visible = true;
            crosshair.gameObject.SetActive(false);
        }

    }
    
}
