



using UnityEngine;
using UnityEngine.UI;

public class StockInfoUI : MonoBehaviour
{
    [Header("UI")]
    public GameObject s_InfoUI;
    public Text s_NameText;
    public Text s_PriceText;
    public Text s_SharesText;
    public Text s_MarketValueText;
    public Text s_NetCostText;
    public Text s_GainLossText;
    public InputField s_AmountInputField;
    public Button s_SellButton;
    public Button s_BuyButton;

    //Singleton
    public static StockInfoUI instance;

    //Variables
    [HideInInspector]
    public int selectedStock;
    private int currentAmount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnGUI()
    {
        // Sorting Buttons for the game
        s_NameText.text = StockManager.instance.stockSaveData[selectedStock].stockName;
        s_PriceText.text = "Price: $" + StockManager.instance.stockSaveData[selectedStock].currentStockPrice.ToString("F0");
        s_SharesText.text = "Shares: " + StockManager.instance.stockSaveData[selectedStock].currentShares;
        s_MarketValueText.text = "Market Value: $" + (StockManager.instance.stockSaveData[selectedStock].currentShares * 
            StockManager.instance.stockSaveData[selectedStock].currentStockPrice).ToString("F0");
        s_NetCostText.text = "Net Cost: $" + StockManager.instance.stockSaveData[selectedStock].netCost.ToString("F0");
        s_GainLossText.text = "Gain/Loss: $" + ((StockManager.instance.stockSaveData[selectedStock].currentShares * 
            StockManager.instance.stockSaveData[selectedStock].currentStockPrice) - StockManager.instance.stockSaveData[selectedStock].netCost).ToString("F0");

        if (currentAmount == 0)
        {
            s_BuyButton.interactable = false;
            s_SellButton.interactable = false;
        }
        else
        {
            if (GameManager.instance.currentMoney >= StockManager.instance.stockSaveData[selectedStock].currentStockPrice * currentAmount)
                s_BuyButton.interactable = true;
            else
                s_BuyButton.interactable = false;

            if (StockManager.instance.stockSaveData[selectedStock].currentShares >= currentAmount)
                s_SellButton.interactable = true;
            else
                s_SellButton.interactable = false;
        }
    }

    public void UpdateAmountInputField(int value)
    {
        s_AmountInputField.text = currentAmount.ToString();
    }

    public void ShowStockInfoUI()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        currentAmount = 0;
        UpdateAmountInputField(currentAmount);
        GameManager.instance.gameStarted = false;
        s_InfoUI.SetActive(true);
    }

    public void CloseStockInfoUI()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        GameManager.instance.gameStarted = true;
        s_InfoUI.SetActive(false);
    }

    public void IncreaseAmount()
    {
        // The amount of money the stock increases if any
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        currentAmount++;
        UpdateAmountInputField(currentAmount);
    }

    public void DecreaseAmount()
    {
        // The amout of money the stock decreases if any
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        currentAmount--;
        if (currentAmount <= 0)
            currentAmount = 0;
        UpdateAmountInputField(currentAmount);
    }

    public void SetAmount()
    {
        // The amout of monry the stock is worth at that time
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        currentAmount = int.Parse(s_AmountInputField.text);
        UpdateAmountInputField(currentAmount);
    }

    public void BuyStock()
    {
        if (GameManager.instance.currentMoney >= StockManager.instance.stockSaveData[selectedStock].currentStockPrice * currentAmount)
        {
            // Buying the stock 
            AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
            GameManager.instance.currentMoney -= StockManager.instance.stockSaveData[selectedStock].currentStockPrice * currentAmount;
            StockManager.instance.stockSaveData[selectedStock].currentShares += currentAmount;
            StockManager.instance.stockSaveData[selectedStock].netCost += StockManager.instance.stockSaveData[selectedStock].currentStockPrice * currentAmount;
            SaveLoadManager.instance.Save();
        }
    }

    public void SellStock()
    {
        if (StockManager.instance.stockSaveData[selectedStock].currentShares >= currentAmount)
        {
            // Selling stock
            AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
            GameManager.instance.currentMoney += StockManager.instance.stockSaveData[selectedStock].currentStockPrice * currentAmount;
            StockManager.instance.stockSaveData[selectedStock].currentShares -= currentAmount;
            StockManager.instance.stockSaveData[selectedStock].netCost -= StockManager.instance.stockSaveData[selectedStock].currentStockPrice * currentAmount;
            if (StockManager.instance.stockSaveData[selectedStock].currentShares == 0)
                StockManager.instance.stockSaveData[selectedStock].netCost = 0;

            SaveLoadManager.instance.Save();
        }
    }
}