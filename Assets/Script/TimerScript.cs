using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [Header("Day Variables")]
    public float dayLength; // Day: True/False
    public Text DayText; // Day Counter



    // Reference to Randomizer Script
    public RandomizerScript randomizerScript;

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

        // Access the price for a specific stock symbol
        float price = randomizerScript.GetPrice("MineCo");
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

            // Calls the Randomizer Script

            


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
