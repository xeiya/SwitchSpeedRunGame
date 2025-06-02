using UnityEngine;

public class CollectSouls : MonoBehaviour
{
    public int collectedSouls;
    public int requiredSouls;

    public string collectableTag = "PickUp";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collectableTag)
        {
            collectedSouls++;
            Destroy(other.gameObject);
        }
    }
}