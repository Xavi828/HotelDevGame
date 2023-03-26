using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShopSistem : MonoBehaviour
{
    public GameObject[] objectsList;
    public DragAndDropSistem dragAndDropSistem;
    public Grid myGrid;

    public void ConstructionObjects(int e)
    {
        var newObject = Instantiate(objectsList[e]);
        newObject.GetComponent<SnapSistem>().objectsGrid = myGrid;
        dragAndDropSistem = newObject.GetComponent<DragAndDropSistem>();
        dragAndDropSistem.buildingMode = true;
        dragAndDropSistem.clicking = true;
    }
}
