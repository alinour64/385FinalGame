using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject settingsPopUp;
    public GameObject backButton;

    private Color originalColor;
    private Color highlightColor;
    private BoxCollider2D boxCollider;
    private PauseMenu pauseMenu;

    void Start()
    {
        originalColor = spriteRenderer.color;
        highlightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
        boxCollider = GetComponent<BoxCollider2D>();
        settingsPopUp.SetActive(false);
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    private void Update()
    {
        if (!pauseMenu.isPaused)
        {
            boxCollider.enabled = false;
        }
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
        settingsPopUp.SetActive(true);
        pauseMenu.turnOffCollider(false);
        pauseMenu.turnOnColliderBack();
    }
}
