using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransScript : MonoBehaviour
{
    public StockMarketScript stockMarketScript;

    [Header("Stock Value")]
    public int price;
    public int stockOwn;

    [Header("Texts")]
    public Text BuyText; // Stock Price
    public Text StockOwnText; // How much stock own
    public Text PurchaseHistoryText; // Prints player purchase history
    public Text PurchaseStockNameText; // Name of Stock




    void Start()
    {
        BuyText.text = price.ToString();
        //StockOwnText.text = "Shares Own: " + stockOwn.ToString();
    }

    void Update()
    {
        StockOwnText.text = "Shares Own: " + stockOwn.ToString(); // Update Text
    }


    public void BuyStock()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);

        if (stockMarketScript.money >= price)
        {
            if (stockMarketScript.RadValue == 0)
            {
                stockMarketScript.RadValue += Random.Range(stockMarketScript.minPrice, stockMarketScript.maxPrice);
            }

            stockMarketScript.money -= price; // Deduct balance
            stockOwn++; // Adds share own when purchase
            stockMarketScript.MoneyTxT.text = "Balance $" + stockMarketScript.money.ToString(); // Update text Balance

            PurchaseHistoryText.text = "Bought for: " + price + " from " + PurchaseStockNameText; // Purchase History in text
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

            PurchaseHistoryText.text = "Sold for: " + price + " from " + PurchaseStockNameText; // Purchase Historu in text
            Debug.Log("Sold for: " + price); // Purhacse History in console

        }

    }

}
