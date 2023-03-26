using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropSistem : MonoBehaviour
{
    private bool clicking = false;
    public bool buildingMode = false;


    #region ShopDragSistem

    private void OnMouseDown()
    {
        if (clicking)
        {
            clicking = false;
        }
        else
        {
            clicking = true;
        }
        
    }

    public void  SwitchBuildingSistem()
    {
        if (buildingMode)
        {
            buildingMode = false;
        }
        else
        {
            buildingMode = true; 
        }
    }

     private void Update()
    {
        if (clicking)
        {
            if (buildingMode)
            {
                transform.position = mouseWorldPos();
            }
            
        }
        
    }

    private void OnMouseDrag()
    {
        
    }

    private Vector3 mouseWorldPos()
    {
        Vector3 mpos = Input.mousePosition;
        mpos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mpos);
    }

    #endregion
}
