using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    // SCRIPT NO LONGER IN USE

    [Header("Depth")]
    public int ItemID;
    public Text BuyPrice; // Price to buy
    public Text SellPrice; // Price to sell
    public Text ShareOwn; // Players amount of shares
    public GameObject StockMarket;


    void Update()
    {
        
        BuyPrice.text = "$" + StockMarket.GetComponent<StockMarketScript>().shopItems[2, ItemID].ToString();
        ShareOwn.text = "Shares Own: " + StockMarket.GetComponent<StockMarketScript>().shopItems[4, ItemID].ToString();

    }
}
