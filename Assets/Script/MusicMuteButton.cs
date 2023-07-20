using UnityEngine;
using UnityEngine.UI;

public class MusicMuteButton : MonoBehaviour
{
    public AudioManager audioManager;
    public Image buttonImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    private void Start()
    {
        // Get the AudioManager instance from the scene
        audioManager = AudioManager.instance;

        // Set the initial sprite for the mute button based on the current mute state
        SetButtonSprite();
    }

    // Function to toggle the music mute state when the button is clicked
    public void OnMuteButtonClick()
    {
        // Call the ToggleMusicMute() function in the AudioManager
        audioManager.ToggleMusicMute();

        // Update the mute button sprite to reflect the new state
        SetButtonSprite();
    }

    // Function to set the button sprite based on the music mute state
    private void SetButtonSprite()
    {
        if (audioManager.musicSource.mute)
        {
            buttonImage.sprite = musicOffSprite; // Set the sprite for muted state
        }
        else
        {
            buttonImage.sprite = musicOnSprite; // Set the sprite for unmuted state
        }
    }
}