using UnityEngine;
using UnityEngine.UI;

public class FastForwardX2ButtonScript : MonoBehaviour
{
    public TimerScript timerScript;
    public Text activeSymbolText;
    private float fastForwardSpeed = 2f; // the speed of the fastfoward

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(FastForward);
    }

    private void FastForward()
    {
        if (Time.timeScale == 1f) // Normal speed
        {
            Time.timeScale = fastForwardSpeed;
            timerScript.dayLength /= fastForwardSpeed;
            activeSymbolText.text = ">>"; // Set the text to the active symbol
        }
        else // Already fast forwarding, return to normal speed
        {
            Time.timeScale = 1f;
            timerScript.dayLength *= fastForwardSpeed;
            activeSymbolText.text = ""; // Clear the text
        }
    }


}