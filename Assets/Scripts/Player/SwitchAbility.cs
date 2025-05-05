using UnityEngine;

public class SwitchAbility : MonoBehaviour
{
    public string targetTag = "Switchable";
    private bool isSwitched = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Debug.Log(isSwitched);
            if (isSwitched == true)
            {
                isSwitched = false;
                Switch();
            }
            else 
            {
                isSwitched = true;
                Switch();
            }   
        }
    }

    public void Switch()
    {
        if (isSwitched == true)
        {
            GameObject[] taggedObject = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject go in taggedObject)
            {
                go.SetActive(false);
            }
        }
        if (isSwitched == false)
        {
            GameObject[] taggedObject = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject go in taggedObject)
            {
                go.SetActive(true);
            }
        }
    }
}
