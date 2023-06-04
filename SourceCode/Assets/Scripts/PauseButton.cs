using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private bool isPaused = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D boxCollider;

    private Color originalColor;
    private Color highlightColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<Collider2D>();

        transform.position = new Vector3(11.5f, 6f, 0f);

        originalColor = spriteRenderer.color;
        highlightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
    }

    void OnMouseEnter()
    {
        spriteRenderer.color = highlightColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }

    void OnMouseDown()
    {
        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu != null)
        {
            pauseMenu.TogglePause();
            isPaused = !isPaused;
        }
    }

    public void GameOver()
    {
        spriteRenderer.enabled = false;

        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }
    public void StartTheGame()
    {
        spriteRenderer.enabled = true;
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
    }
}
