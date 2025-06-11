using UnityEngine;

public class EndGate : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject playerUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            EndMenu();
        }
    }

    public void EndMenu() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerUI.SetActive(false);
        endMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
