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

    public int total = 0; // Buy all 
    public int totalsold = 0; // Sold all


    [Header("Texts")]
    public Text BuyText; // Stock Price
    public Text StockOwnText; // How much stock own
    public Text PurchaseBuyHistoryText; // Prints player buy history
    public Text PurchaseSellHistoryText; // Prints player sell history
    public Text PurchaseStockNameText; // Name of Stock



    void Start()
    {
        //BuyText.text = price.ToString();
        //StockOwnText.text = "Shares Own: " + stockOwn.ToString();
    }

    void Update()
    {
        StockOwnText.text = "Shares Own: " + stockOwn.ToString(); // Update Text

        if (price <= 0)
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

            stockMarketScript.money -= price; // Deduct balance
            stockOwn++; // Adds share own when purchase
            stockMarketScript.MoneyTxT.text = "Balance $" + stockMarketScript.money.ToString(); // Update text Balance

            PurchaseBuyHistoryText.text = PurchaseStockNameText.text + " share bought for: " + price; // Purchase History in text
            Debug.Log("Bought for: " + price); // Purhacse History in console

        }

    }
    public void BuyStockAll()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        while (stockMarketScript.money >= price)
        {
            stockMarketScript.money -= price; // Deduct balance
            stockOwn++; // Adds share own when purchase
            stockMarketScript.MoneyTxT.text = "Balance $" + stockMarketScript.money.ToString(); // Update text Balance
            total += price;
        }
        PurchaseBuyHistoryText.text = PurchaseStockNameText.text + " share bought for: " + total; // Purchase History in text
        Debug.Log("Bought for: " + total); // Purhacse History in console

        total = 0;
    }

    public void SellStock()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);

        if (stockOwn > 0)
        {

            stockMarketScript.money += price; // Adds balance
            stockOwn--; // Deduct share own when purchase
            stockMarketScript.MoneyTxT.text = "Balance $" + stockMarketScript.money.ToString(); // Update text Balance

            PurchaseSellHistoryText.text = PurchaseStockNameText.text + " share sold for: " + price; // Purchase Historu in text
            Debug.Log("Sold for: " + price); // Purhacse History in console

        }

    }

    public void SellStockAll()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);

        if (stockOwn > 0)
        {
            totalsold = price * stockOwn; // Sells everyting then adds to balance
            stockMarketScript.money += totalsold;
            stockMarketScript.MoneyTxT.text = "Balance $" + stockMarketScript.money.ToString(); // Update text Balance

            PurchaseSellHistoryText.text = PurchaseStockNameText.text + " share sold for: " + price * stockOwn; // Purchase History in text
            Debug.Log("Sold for: " + price * stockOwn); // Purhacse History in console

            stockOwn = 0; // stockOwn set to 0
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