using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropSistem : MonoBehaviour
{
    public bool clicking = false;
    public bool buildingMode = true;

    public ShopSistem shopSistem;

    void Start()
    {
        shopSistem = GameObject.Find("Manager").GetComponent<ShopSistem>();
    }

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
    private void Update()
    {
        if (clicking)
        {
            if (buildingMode)
            {
                transform.position = mouseWorldPos();
            }
            
        }

        buildingMode = shopSistem.constructionMode;

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
