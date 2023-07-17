using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StockMarketScript : MonoBehaviour
{
    [Header("Player Stats")]
    public int[,] shopItems = new int[10, 10];
    public float money;
    public Text MoneyTxT; // Players current money
    public Text PurchaseTxT; // Prints player purchase history


    public int minPrice = -10;
    public int maxPrice = 10;
    public int RadNum = 1;
    public int RadValue = 0;
    public int undervalue = 0;


    void Start()
    {
        MoneyTxT.text = "Balance $" + money.ToString(); //Convert float to String

        // ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;

        // Price to Buy/ Sell
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 5;
        shopItems[2, 3] = 50;
        shopItems[2, 4] = 35;
        shopItems[2, 5] = 220;
        shopItems[2, 6] = 342;

        // Price to Buy/ Sell
        shopItems[3, 1] = 10;
        shopItems[3, 2] = 5;
        shopItems[3, 3] = 50;
        shopItems[3, 4] = 35;
        shopItems[3, 5] = 220;
        shopItems[3, 6] = 342;

        // Shares own
        shopItems[4, 1] = 0;
        shopItems[4, 2] = 0;
        shopItems[4, 3] = 0;
        shopItems[4, 4] = 0;
        shopItems[4, 5] = 0;
        shopItems[4, 6] = 0;


    }

    public void Update()
    {
        GameObject ButtonRef = GameObject.Find("Buy");

        if ((shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) < 2)
        {
            undervalueMethod();
            (shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) = undervalue + (shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]);
        }
    }


    public void Buy()
    {
        //GameObject ButtonRef = GameObject.FindGameObjectWithTag("Needed").GetComponent<EventSystem>().currentSelectedGameObject;
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        GameObject ButtonRef = GameObject.Find("Buy");
        

        if (money >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            if (RadValue == 0)
            {
                RadValue += Random.Range(minPrice, maxPrice);
            }
            money -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]; // Deduct balance
            shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID]++; // Adds share own when purchase
            MoneyTxT.text = "Balance $" + money.ToString(); // Update text Balance
            ButtonRef.GetComponent<ButtonInfo>().ShareOwn.text = shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

            PurchaseTxT.text = "Bought for: " + shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]; // Purchase Historu in text
            Debug.Log("Bought for: " + shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]); // Purhacse History in console
            
        }

    }
    
    public void Sell()
    {
        //GameObject ButtonRef = GameObject.FindGameObjectWithTag("Needed").GetComponent<EventSystem>().currentSelectedGameObject;
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        GameObject ButtonRef = GameObject.Find("Buy");

        if (shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID] > 0)
        {
            money += shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]; // Adds to Balance
            shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID]--; // Deducts Share
            MoneyTxT.text = "Balance $" + money.ToString(); // Update text Balance

            PurchaseTxT.text = "Sold for: " + shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]; // Selling History in text
            Debug.Log("Sold for: " + shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]); // Selling History in console
        }
    }

    public void RandomMethod()
    {
        GameObject ButtonRef = GameObject.Find("Buy");
        //GameObject TimerRef = GameObject.Find("TimerScript");

        // Changing list Value
        RadNum = Random.Range(minPrice, maxPrice);
        Debug.Log("Random Number: " + RadNum);
        RadValue = RadNum * shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
        shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]  += RadValue / 10;

        shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] = shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];


    }

    public void undervalueMethod()
    {
        undervalue = Random.Range(1, 10);
        Debug.Log("Under Value number: " + undervalue);
    }

}
