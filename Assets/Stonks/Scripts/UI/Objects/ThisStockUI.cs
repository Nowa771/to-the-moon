
using UnityEngine;
using UnityEngine.UI;

public class ThisStockUI : MonoBehaviour 
{
    [Header("UI")]
    public Image stockBackground;
    public Text stockNameText;
    public Text stockSharesText;
    public Text stockPriceText;
    public Text stockMoneyChangeText;

    [Header("Colors")]
    public Color greenColor;
    public Color redColor;

    //Variables
    [HideInInspector]
    public int thisStock;

    private void OnGUI()
    {
        stockNameText.text = StockManager.instance.stockSaveData[thisStock].stockName;
        stockSharesText.text = StockManager.instance.stockSaveData[thisStock].currentShares.ToString();
        stockPriceText.text = StockManager.instance.stockSaveData[thisStock].currentStockPrice.ToString("F0");
        stockMoneyChangeText.text = StockManager.instance.stockSaveData[thisStock].lastStockMoneyChange.ToString("F0");
        if (StockManager.instance.stockSaveData[thisStock].lastStockMoneyChange > 0)
            stockMoneyChangeText.color = greenColor;
        else
            stockMoneyChangeText.color = redColor;
    }

    public void ShowStockUI()
    {
        StockInfoUI.instance.selectedStock = thisStock;
        StockInfoUI.instance.ShowStockInfoUI();
    }
}