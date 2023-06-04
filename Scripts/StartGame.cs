using UnityEngine;

public class StartGame : MonoBehaviour
{
    private bool gameStarted = false;

    private void Start()
    {
        // Pause the game at the beginning
        Time.timeScale = 0f;
    }


    private void OnMouseDown()
    {
        if (!gameStarted)
        {
            StartGameLogic();
        }
    }

    private void StartGameLogic()
    {
        // Perform actions when the game starts
        Debug.Log("Game started!");
        // Enable controls and resume gameplay
        gameStarted = true;
        Time.timeScale = 1f;
    }
}
