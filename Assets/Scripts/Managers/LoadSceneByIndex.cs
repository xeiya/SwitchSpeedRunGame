using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour
{
    public void LoadSceneByBuildIndex(int buildIndex)
    {
        //Makes sure timeScale is set to 1
        Time.timeScale = 1.0f;

        //Load the scene with the given build index
        SceneManager.LoadScene(buildIndex);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
