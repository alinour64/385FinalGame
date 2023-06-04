using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Color originalColor;
    private Color highlightColor;

    void Start()
    {
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
        PauseMenu pauseMenu = GetComponentInParent<PauseMenu>();
        pauseMenu.Resume();
    }
}
