



using UnityEngine;

[CreateAssetMenu(fileName = "Stock", order = 1000)]
public class StockObject : ScriptableObject
{
    [Header("Info")]
    public string stockName;

    [Header("Variables")]
    public int minStartPrice;
    public int maxStartPrice;
}