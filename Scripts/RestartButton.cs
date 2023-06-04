using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private PauseMenu pauseMenu;
    private Color originalColor;
    private Color highlightColor;

    void Start()
    {
        originalColor = spriteRenderer.color;
        highlightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
        pauseMenu = FindObjectOfType<PauseMenu>();
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
        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu.IsPaused || pauseMenu.gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            pauseMenu.Resume();
        }
        
    }
}
