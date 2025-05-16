using UnityEngine;

public class InputManager : MonoBehaviour

{
    PlayerCam playerCam;
    Rigidbody playerRb;
    private void OnGameStateChanged(GameState newGameState) 
    {


        switch (newGameState) 
        { 
            case GameState.Gameplay:
                break;
            case GameState.Paused: 
                break;
            default:
                break;
        }
    }
}
