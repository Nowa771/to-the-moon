using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StockMarketScript : MonoBehaviour
{
    [Header("Player Stats")]
    public int[,] shopItems = new int[5, 5];
    public float money;
    public Text MoneyTxT; // Players current money
    

    void Start()
    {
        MoneyTxT.text = "Balance $" + money.ToString(); //Convert float to String

        // ID's
        shopItems[1, 1] = 1;

        // Price to Buy/ Sell
        shopItems[2, 1] = 10;

        // Price to Buy/ Sell
        shopItems[4, 1] = 10;

        // Shares own
        shopItems[4, 1] = 0;

    }

    public void Buy()
    {
        //GameObject MineCoRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        GameObject MineCoRef = GameObject.Find("StockCom");

        if (money >= shopItems[2, MineCoRef.GetComponent<MineCo>().ItemID])
        {
            money -= shopItems[2, MineCoRef.GetComponent<MineCo>().ItemID]; // Deduct balance
            shopItems[4, MineCoRef.GetComponent<MineCo>().ItemID]++; // Adds share own when purchase
            MoneyTxT.text = "Balance $" + money.ToString();
            MineCoRef.GetComponent<MineCo>().mineCoShareOwn.text = shopItems[4, MineCoRef.GetComponent<MineCo>().ItemID].ToString();

        }

    }
    
    public void Sell()
    {
        //GameObject MineCoRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        GameObject MineCoRef = GameObject.Find("StockCom");

        if (shopItems[4, MineCoRef.GetComponent<MineCo>().ItemID] > 0)
        {
            money += shopItems[3, MineCoRef.GetComponent<MineCo>().ItemID]; // Adds to Balance
            shopItems[4, MineCoRef.GetComponent<MineCo>().ItemID]--; // Deducts Share
            MoneyTxT.text = "Balance $" + money.ToString();
        }
    }
}
