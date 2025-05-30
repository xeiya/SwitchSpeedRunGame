using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("Pause Menu")]
    private bool isPaused;
    public GameObject pauseMenu;
    public GameObject playerUI;
    
    [Header("Timer")]
    public float elapsedTime;
    public TMP_Text timerText;


    void Start()
    {
        if (gm == null)
            gm = this;
        else
            Destroy(gameObject);

        elapsedTime = 0;

        Time.timeScale = 1f;
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        TimeTextStructure();
    }
    public void TimeTextStructure() 
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt(elapsedTime * 1000 % 1000);
        timerText.text = string.Format("{0:00}'{01:00}''{2:000}", minutes, seconds, milliseconds);
    }

    public void TogglePause() 
    {
        playerUI.SetActive(!playerUI.activeInHierarchy);
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);

        Time.timeScale = isPaused ? 1 : 0;
        isPaused = !isPaused;

        Cursor.lockState = pauseMenu.activeInHierarchy ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ResetTime() 
    { 
        elapsedTime = 0;
    }
}
