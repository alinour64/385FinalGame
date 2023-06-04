using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    private SpriteRenderer[] buttonRenderers;
    private Collider2D resumeCollider;
    public GameObject popUp; 
    private SpriteRenderer popUpRenderer; 
    public bool gameOver = false;

    void Start()
    {
        buttonRenderers = GetComponentsInChildren<SpriteRenderer>();
        SetButtonPositions();

        resumeCollider = transform.Find("ResumeButton").GetComponent<Collider2D>();
        if(gameOver)
        {
            endGame();
        }
        if (popUp != null)
        {
            popUpRenderer = popUp.GetComponent<SpriteRenderer>();
        }

        foreach (SpriteRenderer sr in buttonRenderers)
        {
            sr.enabled = false;
        }

        if (popUpRenderer != null)
        {
            popUpRenderer.enabled = false;
        }
    }
    void Update()
    {
        bool isMouseOverResumeButton = resumeCollider.bounds.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (!gameOver && Input.GetKeyDown(KeyCode.Escape) && !isMouseOverResumeButton)
        {
            TogglePause();
        }
    }



    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = isPaused;
        }

        foreach (SpriteRenderer sr in buttonRenderers)
        {
            sr.enabled = isPaused;
        }

        if (popUpRenderer != null)
        {
            popUpRenderer.enabled = isPaused;
        }
    }



    private void SetButtonPositions()
    {
        Vector3 menuPosition = transform.position;
        Vector3 resumePosition = new Vector3(0f, -40f, 0f);
        Vector3 settingsPosition = new Vector3(90f, 0f, 0f);
        Vector3 restartPosition = new Vector3(-90f, 0f, 0f);
        

        transform.position = menuPosition;
        transform.Find("ResumeButton").transform.localPosition = resumePosition;
        transform.Find("SettingsButton").transform.localPosition = settingsPosition;
        transform.Find("RestartButton").transform.localPosition = restartPosition;

        turnOffCollider(isPaused);
    }
    public void turnOffCollider(bool paused)
    {
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = paused;
        }
    }
    public void turnOnColliderBack()
    {
        Transform backButtonTransform = transform.Find("SettingsButton/SettingsPopUp/BackButton");
        Collider2D backButtonCollider = backButtonTransform.GetComponent<Collider2D>();
        backButtonCollider.enabled = true;
    }


    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        foreach (SpriteRenderer sr in buttonRenderers)
        {
            sr.enabled = false;
        }

        if (popUpRenderer != null)
        {
            popUpRenderer.enabled = false;
        }
    }

    public bool IsPaused
    {
        get { return isPaused; }
    }
    public void endGame()
    {
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
