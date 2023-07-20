using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransScript : MonoBehaviour
{
    public StockMarketScript stockMarketScript;
    public TimerScript timerScript;


    [Header("Stock Value")]
    public int price;
    public int stockOwn;

    public int minPrice = -10;
    public int maxPrice = 10;
    public int RadNum = 1;
    public int RadValue = 0;
    public int undervalue = 0;

    [Header("Texts")]
    public Text BuyText; // Stock Price
    public Text StockOwnText; // How much stock own
    public Text PurchaseHistoryText; // Prints player purchase history
    public Text PurchaseStockNameText; // Name of Stock



    void Start()
    {
        //BuyText.text = price.ToString();
        //StockOwnText.text = "Shares Own: " + stockOwn.ToString();
    }

    void Update()
    {
        StockOwnText.text = "Shares Own: " + stockOwn.ToString(); // Update Text

        if (price <= 1)
        {
            price = 3;
            undervalueMethod();

            price = price + undervalue;
        }

        //RandomUpdate();
        BuyText.text = "$" + price.ToString();

    }


    public void BuyStock()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);

        if (stockMarketScript.money >= price)
        {
            if (RadValue == 0)
            {
                RadValue += Random.Range(minPrice, maxPrice);
            }

            stockMarketScript.money -= price; // Deduct balance
            stockOwn++; // Adds share own when purchase
            stockMarketScript.MoneyTxT.text = "Balance $" + stockMarketScript.money.ToString(); // Update text Balance

            PurchaseHistoryText.text = PurchaseStockNameText.text + " share bought for: " + price; // Purchase History in text
            Debug.Log("Bought for: " + price); // Purhacse History in console

        }

    }

    public void SellStock()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);

        if (stockOwn > 0)
        {

            stockMarketScript.money += price; // Deduct balance
            stockOwn--; // Deduct share own when purchase
            stockMarketScript.MoneyTxT.text = "Balance $" + stockMarketScript.money.ToString(); // Update text Balance

            PurchaseHistoryText.text = PurchaseStockNameText.text + " share sold for: " + price; // Purchase Historu in text
            Debug.Log("Sold for: " + price); // Purhacse History in console

        }

    }

    public void RandomMethod()
    {

        //Changing list Value
        RadNum = Random.Range(minPrice, maxPrice);
        Debug.Log("Random Number: " + RadNum);
        RadValue = RadNum * price;
        price += RadValue / 10;

    }

    public void undervalueMethod()
    {

        undervalue = Random.Range(1, 10);
        Debug.Log("Under Value number: " + undervalue);
    }

}