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
        objectsTypeLists = managerGameObject.GetComponent<ShopSistem>().typeObjectsList;
        budgetSistem = managerGameObject.GetComponent<BudgetSistem>();
        walletMoney = budgetSistem.walletMoney;
        
    }

    public void PriceCollector(int i, int e)
    {
        objectsList.Clear();
        objectsList = objectsTypeLists[i];

        priceToPay = objectsList[e].GetComponent<ObjectData>().objectPrice;

        walletMoney -= priceToPay;
        budgetSistem.walletMoney = walletMoney;
    }

}
