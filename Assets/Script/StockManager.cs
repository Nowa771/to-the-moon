using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockManager : MonoBehaviour
{
    public RandomizerScript randomizerScript;
    public Text priceText;

    void Start()
    {
        // Access the price for a specific stock symbol
        float price = randomizerScript.GetPrice("MineCo");

        // Update the UI Text componentwith the pice
        priceText.text = "price for MineCo: $" + price;
    }
}