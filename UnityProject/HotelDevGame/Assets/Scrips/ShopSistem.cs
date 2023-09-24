using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class ShopSistem : MonoBehaviour
{
    public GameObject[] objectsList;
    public DragAndDropSistem dragAndDropSistem;
    public Grid myGrid;
    public bool constructionMode;

    private ObjectData objectData;
    private List<GameObject> wallList = new List<GameObject>();
    private List<GameObject> floorList = new List<GameObject>();
    private List<GameObject> furnitureList = new List<GameObject>();
    private List<GameObject> toiletList = new List<GameObject>();
    private List<GameObject> staffList = new List<GameObject>();

    public List<List<GameObject>> typeObjectsList = new List<List<GameObject>>();

    private void Start()
    {
        constructionMode = false;

        #region ObjectClassifier
        for (int i = 0; i < objectsList.Length; i++)
        {
            objectData = objectsList[i].GetComponent<ObjectData>();
            switch (objectData.objectType)
            {
                case ObjectData.ObjectType.Wall:
                    wallList.Add(objectsList[i]);
                    break;
                case ObjectData.ObjectType.Floor:
                    floorList.Add(objectsList[i]);
                    break;
                case ObjectData.ObjectType.Furniture:
                    furnitureList.Add(objectsList[i]);
                    break;
                case ObjectData.ObjectType.Toilet:
                    toiletList.Add(objectsList[i]);
                    break;
                case ObjectData.ObjectType.Staff:
                    staffList.Add(objectsList[i]);
                    break;
                default:
                    Debug.Log("Error al clasificar las listas de objetos");
                    break;
            }
        }

        typeObjectsList.Add(wallList);
        typeObjectsList.Add(floorList);
        typeObjectsList.Add(furnitureList);
        typeObjectsList.Add(toiletList);
        typeObjectsList.Add(staffList);

        #endregion
    }

    public void ConstructionMode()
    {
        if (constructionMode)
        {
            //Time.timeScale = 1;
            constructionMode = false;
        }

        else
        {
            //Time.timeScale = 1;
            constructionMode = true;
        }

    }

    public void ConstructionObjects(int i, int e)
    {
        List<GameObject> gameObjects = typeObjectsList[i];
        Debug.Log("i:" + i + " e:" + e + " typeObjectsList:" + typeObjectsList.Count + " gameObjects" + gameObjects.Count);
        var newObject = Instantiate(gameObjects[e]);
        dragAndDropSistem = newObject.GetComponent<DragAndDropSistem>();
        dragAndDropSistem.clicking = true;

        newObject.AddComponent<SnapSistem>();

        StartCoroutine(AssignGridCoroutine(newObject));
    }
    IEnumerator AssignGridCoroutine(GameObject newObject)
    {
        yield return new WaitForEndOfFrame();
        newObject.GetComponent<SnapSistem>().objectsGrid = myGrid;
    }
}
