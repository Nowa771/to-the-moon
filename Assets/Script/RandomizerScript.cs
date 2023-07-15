using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizerScript : MonoBehaviour
{
    public float minPrice = 10f;
    public float maxPrice = 100f;
    public string[] stockSymbols;

    private Dictionary<string, float> stockPrices = new Dictionary<string, float>();

    void Start()
    {
        GenerateRandomPrices();
    }

    void GenerateRandomPrices()
    {
        foreach (string symbol in stockSymbols)
        {
            float randomPrice = Random.Range(minPrice, maxPrice);
            stockPrices[symbol] = randomPrice;
        }
    }

    public float GetPrice(string symbol)
    {
        if (stockPrices.TryGetValue(symbol, out float price))
        {
            return price;
        }

        Debug.LogError("Stock symbol not found: " + symbol);
        return 0f; 
    }


}
