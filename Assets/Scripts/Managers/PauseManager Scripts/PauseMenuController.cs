using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;

        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState) 
    {
        pauseMenuUI.SetActive(newGameState == GameState.Paused);
    }
}
