using UnityEngine;

public class EndGate : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject playerUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerUI.SetActive(false);
        }
    }

    public void EndMenu() 
    { 
        endMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
