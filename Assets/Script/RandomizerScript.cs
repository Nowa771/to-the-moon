using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizerScript : MonoBehaviour
{
    // SCRIPT NO LONGER IN USE


    public float minPrice = 10f;
    public float maxPrice = 100f;
    public string[] stockSymbols;


    
    // Reference to Script
    public StockMarketScript stockMarketScript;



    private Dictionary<string, float> stockPrices = new Dictionary<string, float>();

    

    void Start()
    {
        GenerateRandomPrices();
    }

    public void GenerateRandomPrices()
    {
        foreach (string symbol in stockSymbols)
        {
            float randomPrice = Random.Range(minPrice, maxPrice);
            stockPrices[symbol] = randomPrice;
        }




        // Changing list Value
        GameObject shopObjectRef = GameObject.Find("StockMarketScript");

        // NEEDS FIXING
        //stockMarketScript.shopItems[2, shopObjectRef.GetComponent<MineCo>().ItemID] = 2 * stockMarketScript.shopItems[2, shopObjectRef.GetComponent<MineCo>().ItemID];



        // Purhcase History console
        //Debug.Log(stockMarketScript.shopItems[2, shopObjectRef.GetComponent<MineCo>().ItemID]);

    }

    public float GenerateRandomPrices(string symbol)
    {
        if (stockPrices.TryGetValue(symbol, out float price))
        {
            return price;
        }

        Debug.LogError("Stock symbol not found: " + symbol);
        return 0f;
    }


}
