using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstructionPrice : MonoBehaviour
{
    private List<List<GameObject>> objectsTypeLists = new List<List<GameObject>>();
    private List<GameObject> objectsList = new List<GameObject>();

    private GameObject managerGameObject;
    private float priceToPay;
    private BudgetSistem budgetSistem;
    private float walletMoney;


    private void Start()
    {
        managerGameObject = GameObject.Find("Manager");
        budgetSistem = managerGameObject.GetComponent<BudgetSistem>();
        walletMoney = budgetSistem.walletMoney;
        
    }

    public void PriceCollector(int i, int e)
    {
        Debug.Log("i=" + i + "e" + e);

        objectsList = objectsTypeLists[i];

        Debug.Log(objectsTypeLists.Count + " " + objectsList.Count);

        priceToPay = objectsList[e].GetComponent<ObjectData>().objectPrice;

        walletMoney -= priceToPay;
        budgetSistem.walletMoney = walletMoney;

        objectsList.Clear();
        Debug.Log(objectsTypeLists.Count + " " + objectsList.Count);
    }

}
