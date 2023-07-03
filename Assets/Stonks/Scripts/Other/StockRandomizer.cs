

using System.Collections.Generic;
using UnityEngine;

public class StockRandomizer : MonoBehaviour
{
    public static float ReturnRandom()
    {
        List<float> values = new List<float>();

        int i = new int();
        while (i < 40)
        {
            values.Add(Random.Range(-10f, 10f));
            i++;
        }
        i = 0;
        while (i < 30)
        {
            values.Add(Random.Range(-20f, 20f));
            i++;
        }
        i = 0;
        while (i < 20)
        {
            values.Add(Random.Range(-10f, 10f));
            i++;
        }
        i = 0;
        while (i < 7)
        {
            values.Add(Random.Range(-10f, 10f));
            i++;
        }
        i = 0;
        while (i < 2)
        {
            values.Add(Random.Range(-50f, 50f));
            i++;
        }
        i = 0;
        while (i < 1)
        {
            values.Add(Random.Range(-1000f, 1000f));
            i++;
        }

        float returnPostive = Random.Range(0, 2);
        if (returnPostive == 0)
            return Mathf.Abs(values[Random.Range(0, values.Count)]);
        else
            return values[Random.Range(0, values.Count)];
    }
}