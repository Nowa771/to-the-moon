

using System;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour 
{
    //Singleton
    public static StockManager instance;

    //Data
    public List<StockObject> defaultStocks;
    public List<StockSaveData> stockSaveData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}

[Serializable]
public class StockSaveData
{
    //Info
    public string stockName;

    //Variables
    public int currentShares;
    public float currentStockPrice;
    public float lastStockMoneyChange;
    public float netCost;
}