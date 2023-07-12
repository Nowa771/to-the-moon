using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [Header("Day Variables")]
    public float dayLength; // Day: True/False
    public Text DayText; // Day Counter




    // Hidden Variables
    [HideInInspector]
    public bool gameStarted, dayOver;
    [HideInInspector]
    public float currentTime, currentMoney;
    [HideInInspector]
    public int currentDay;



    void Start()
    {
        gameStarted = true;
        dayOver = false;
    }

    
    void Update()
    {
        NewDate(); // Day Counter
    }

    private void NewDate()
    {
        if (dayOver == true) // When dayOver is true it adds another day
        {
            currentTime = dayLength;
            currentDay++;
            DayText.text = "Day: " + currentDay;
            NextDay();
        }
        Timer();
    }

    private void Timer() // If timer is 0 -> set dayOver = true
    {
        if (dayOver == false && gameStarted == true) // Day is false AND game is true
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0) // If timer is less then 0
                dayOver = true;
        }
    }

    private void NextDay() // Resets dayOver back to false
    {
        //Debug.Log("Day: " + currentDay); // Test day counter
        dayOver = false;
    }

}
