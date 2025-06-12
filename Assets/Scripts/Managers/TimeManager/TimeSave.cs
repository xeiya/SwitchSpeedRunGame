using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeSave : MonoBehaviour
{
    [Header("Time Text's")]
    [SerializeField] private TMP_Text yourTimeText;
    [SerializeField] private TMP_Text bestTimeText;

    private float yourTime;
    private float bestTime;
    public float elapsedTime;

    private void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime" + SceneManager.GetActiveScene().buildIndex, Mathf.Infinity);
        UpdateBestTimeText();

        elapsedTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.gm.elapsedTime < PlayerPrefs.GetFloat("BestTime" + SceneManager.GetActiveScene().buildIndex, 3600f))
            PlayerPrefs.SetFloat("BestTime" + SceneManager.GetActiveScene().buildIndex, GameManager.gm.elapsedTime);
            UpdateBestTimeText();

        yourTimeText.text = TimeString(GameManager.gm.elapsedTime);
    }
    private void UpdateBestTimeText() 
    {
        bestTimeText.text = TimeString(PlayerPrefs.GetFloat("BestTime" + SceneManager.GetActiveScene().buildIndex, 3600f));
    }
    string TimeString(float time) 
    { 
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt(time * 1000 % 1000);
        return (string.Format("{0:00}'{01:00}''{2:000}", minutes, seconds, milliseconds));
    }
}
