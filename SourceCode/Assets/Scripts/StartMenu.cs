using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject startPopUp;
    public GameObject controlsButton;

    private bool gameStarted = false;
    
    public SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color highlightColor;
    private PauseMenu pauseMenu;
    private PauseButton pauseButton;



    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        pauseButton = FindObjectOfType<PauseButton>();

        originalColor = spriteRenderer.color;
        highlightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
        Time.timeScale = 0f;
        pauseMenu.gameOver = true;
        pauseButton.GameOver();

    }
    void OnMouseEnter()
    {
        spriteRenderer.color = highlightColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }
    private void OnMouseDown()
    {
        if (!gameStarted)
        {
            HandleStartGame();
        }
        pauseMenu.gameOver = false;
        pauseButton.StartTheGame();

    }

    private void HandleStartGame()
    {
        Debug.Log("Game started!");

        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        if (startPopUp != null)
        {
            startPopUp.SetActive(false);
        }
        if(controlsButton != null)
        {
            controlsButton.SetActive(false);
        }

        gameStarted = true;
        Time.timeScale = 1f;
    }
}
