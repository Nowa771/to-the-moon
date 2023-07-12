using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    public string[] stockSymbols; // Add the Stock symbls
    public float minStockPrice; // Add the minimum stock price
    public float maxStockPrice; // Add the maximum Stock price

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (string symbol in stockSymbols)
        {
            // Generate a random stoick price between minStockPrice and maxStock price
            float stockPrice = Random.Range(minStockPrice, maxStockPrice);

            Debug.Log(symbol + " " + stockPrice.ToString("C"));
        }

    }

}
