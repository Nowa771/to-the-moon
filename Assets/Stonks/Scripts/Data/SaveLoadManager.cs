


using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour 
{
    //Singleton
    public static SaveLoadManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        CreateSave();
    }

    public void CreateSave()
    {
        if (!File.Exists(Application.persistentDataPath + "/save.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Create);

            InitializeStocks();
            SaveData newData = new SaveData
            {
                savedMoney = 500,
                savedDay = 0,
                savedStocks = StockManager.instance.stockSaveData
            };

            bf.Serialize(file, newData);
            file.Close();
        }

        Load();
    }

    public void Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            SaveData savedData = (SaveData)bf.Deserialize(file);
            GameManager.instance.currentMoney = savedData.savedMoney;
            GameManager.instance.currentDay = savedData.savedDay;
            StockManager.instance.stockSaveData = savedData.savedStocks;

            file.Close();
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
            DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
            dataDir.Delete(true);
            CreateSave();
        }
    }

    public void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            SaveData newData = new SaveData
            {
                savedMoney = GameManager.instance.currentMoney,
                savedDay = GameManager.instance.currentDay,
                savedStocks = StockManager.instance.stockSaveData
            };

            bf.Serialize(file, newData);
            file.Close();
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
            DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
            dataDir.Delete(true);
            CreateSave();
        }
    }

    public void InitializeStocks()
    {
        for (int i = 0; i < StockManager.instance.defaultStocks.Count; i++)
        {
            StockSaveData newStockSave = new StockSaveData
            {
                stockName = StockManager.instance.defaultStocks[i].name,
                currentStockPrice = UnityEngine.Random.Range(StockManager.instance.defaultStocks[i].minStartPrice, StockManager.instance.defaultStocks[i].maxStartPrice),
                currentShares = 0,
                lastStockMoneyChange = 0,
                netCost = 0,
            };

            StockManager.instance.stockSaveData.Add(newStockSave);
        }      
    }
}

[Serializable]
class SaveData
{
    //Game Manager
    public float savedMoney;
    public int savedDay;

    //Stock Manager
    public List<StockSaveData> savedStocks;
}