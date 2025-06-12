using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadBestTime : MonoBehaviour
{
    [SerializeField] private int levelName;
    [SerializeField] private TMP_Text bestTimeText;

    private void Update()
    {
        UpdateBestTimeText();
    }
    private void UpdateBestTimeText() 
    {
        bestTimeText.text = TimeString(PlayerPrefs.GetFloat("BestTime" + levelName, 3600));
    }

    string TimeString(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt(time * 1000 % 1000);
        return (string.Format("{0:00}'{01:00}''{2:000}", minutes, seconds, milliseconds));
    }
}
