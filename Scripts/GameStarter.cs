using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject startButton;
    public GameObject startPopUp;

    private bool gameStarted = false;

    private void Start()
    {
        // Pause the game at the beginning
        Time.timeScale = 0f;
    }

    private void Update()
    {
        // Check if the game is started
        if (gameStarted)
        {
            // Continue game logic here
            // Allow controls and gameplay actions
        }
        else
        {
            // Game not started, wait for start button click
            // Disable controls and pause gameplay
        }
    }

    private void OnMouseDown()
    {
        if (!gameStarted)
        {
            HandleStartGame();
        }
    }

    private void HandleStartGame()
    {
        // Perform actions when the game starts
        Debug.Log("Game started!");

        // Disable the start button
        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        // Hide the parent object of the box collider
        if (startPopUp != null)
        {
            startPopUp.SetActive(false);
        }

        // Enable controls and resume gameplay
        gameStarted = true;
        Time.timeScale = 1f;
    }
}
