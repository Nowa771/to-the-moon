using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    public TimerScript timerScript; //assign a reference to the TimerScript component
    public Text pauseSymbolText; // to show it the time is paused
    private bool isPaused; // keep track of the current pause state.

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePause);
        isPaused = false;
    }

    private void TogglePause()
    {
        AudioManager.instance.PlayAudioClip(AudioManager.instance.uiClickSound);
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseSymbolText.text = "||"; // Set the text to the pause symbol
        }
        else
        {
            Time.timeScale = 1f;
            pauseSymbolText.text = ""; // Clear the text
        }
        timerScript.gameStarted = !isPaused;
    }
}
