using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineCo : MonoBehaviour
{

    [Header("Depth")]
    public int ItemID;
    public Text mineCoBuyPrice; // Price to buy
    public Text mineCoSellPrice; // Price to sell
    public Text mineCoShareOwn; // Players amount of shares
    public GameObject StockMarket;


    void Update()
    {
        
        mineCoBuyPrice.text = "$" + StockMarket.GetComponent<StockMarketScript>().shopItems[2, ItemID].ToString();
        mineCoShareOwn.text = StockMarket.GetComponent<StockMarketScript>().shopItems[4, ItemID].ToString();

    }
}
