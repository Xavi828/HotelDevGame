using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Vector2 buttonPosition;

    public GameObject buttonPrefab;
    public Vector2 buttonStartPosition;
    public List<GameObject> typeButtons = new List<GameObject>();

    private int buttonColNum;
    private int buttonRowNum;
    private int buttonNum;
    private int buttonPageSelect;
    private int pageActiveNum;
    private bool shopPanelActive;
    private bool optionsPanelActive;
    private GameObject shopGameObject;
    private ShopSistem shopSistem;
    private List<GameObject> objectList = new List<GameObject>();
    private List<List<GameObject>> listType = new List<List<GameObject>>();
    private List<GameObject> pages = new List<GameObject>();

    void Start()
    {
        shopPanel.SetActive(false);
        shopPanelActive = false;
        optionsPanel.SetActive(false);
        optionsPanelActive = false;

        buttonColNum = 0;
        buttonRowNum = 0;
        buttonNum = 0;

        shopGameObject = GameObject.Find("Manager");
        shopSistem = shopGameObject.GetComponent<ShopSistem>();
        listType = shopSistem.typeObjectsList;

        for (int u = 0; u < typeButtons.Count; u++)
        {
            CreateButtons(u);
            typeButtons[u].SetActive(false);
        }
    }

    public void OpenAndCloseShop()
    {
        if (shopPanelActive)
        {
            shopPanel.SetActive(false);
            shopPanelActive = false;
            for (int i = 0; i < typeButtons.Count; i++)
            {
                typeButtons[i].SetActive(false);
            }
        }
        else
        {
            shopPanel.SetActive(true);
            shopPanelActive = true;
            ChoseObjectsType(0);
        }
    }

    public void ChoseObjectsType(int i)
    {
        pages.Clear();
        for (int e = 0; e < typeButtons.Count; e++)
        {
            typeButtons[e].SetActive(false);
        }
        typeButtons[i].SetActive(true);

        foreach (Transform child in typeButtons[i].transform)
        {
            pages.Add(child.gameObject);
        }

        for (int c = 0; c < pages.Count; c++)
        {
            pages[c].SetActive(false);
        }
        pages[0].SetActive(true);
        pageActiveNum = 0;
    }

    public void ChangeShopPage(bool nextPage)
    {
        if (nextPage)
        {
            if (!(pageActiveNum == (pages.Count - 1)))
            {
                pages[pageActiveNum].SetActive(false);
                pageActiveNum++;
                pages[pageActiveNum].SetActive(true);
            }
            else
            {
                Debug.Log("No hay mas paguinas: " + pageActiveNum);
            }
            
        }
        else
        {
            if (!(pageActiveNum == 0))
            {
                pages[pageActiveNum].SetActive(false);
                pageActiveNum--;
                pages[pageActiveNum].SetActive(true);
            }
            else
            {
                Debug.Log("No hay menos paguinas: " + pageActiveNum);
            }
        }
    }

    public void CreateButtons(int i)
    {
        
        objectList = listType[i];

        for (int a = -1; a < objectList.Count / 15; a++)
        {
            GameObject page = new GameObject("page" + (a + 1));
            page.transform.parent = typeButtons[i].transform;
            pages.Add(page);
        }

        for (int e = 0; e < objectList.Count; e++)
        {
            GameObject newButton = Instantiate(buttonPrefab, pages[buttonPageSelect].transform);
            newButton.name = objectList[e].GetComponent<ObjectData>().objectName;

            Vector2 vector2 = new Vector2(buttonColNum, buttonRowNum);
            newButton.GetComponent<RectTransform>().position = buttonStartPosition + buttonPosition * vector2;

            if (buttonColNum == 2)
            {
                buttonColNum = -1;
                buttonRowNum++;
            }
            if (buttonColNum > 2)
            {
                Debug.Log("Error en la linia 73 del Codigo GameHud");
            }
            else
            {
                buttonColNum++;
            }

            if (buttonNum == 14)
            {
                buttonNum = 0;
                buttonPageSelect++;
                buttonRowNum = 0;
            }
            else
            {
                buttonNum++;
            }
            int z = e;
            newButton.GetComponent<Button>().onClick.AddListener(() => shopGameObject.GetComponent<ShopSistem>().ConstructionObjects(i, z));
            newButton.GetComponent<Button>().onClick.AddListener(() => shopGameObject.GetComponent<ConstructionPrice>().PriceCollector(i, z));
        }

        if (pages.Count >= 1)
        {
            for (int b = 1; b < pages.Count; b++)
            {
                pages[b].SetActive(false);
            }
        }
        else
        {
            pages[0].SetActive(true);
        }

        buttonColNum = 0;
        buttonRowNum = 0;
        buttonNum = 0;
        buttonPageSelect = 0;
        pages.Clear();
    }
}
