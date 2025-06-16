using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReset : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 spawnPos;
    private Quaternion spawnRot;

    [Header("UI")]
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject finishUI;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject pauseUI;
    private void Awake()
    {
        spawnPos = transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        { 
            GameManager.gm.ResetTime();
            EnablePlayerUI();
            ResetPlayer();
        }
    }

    private void ResetPlayer() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    private void EnablePlayerUI() 
    {
        playerUI.SetActive(true);
        deathUI.SetActive(false);
        pauseUI.SetActive(false);
        finishUI.SetActive(false);
    }
}
