using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public int collectedItems;
    public int requiredItems;

    public string collectableTag = "PickUp";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collectableTag)
        {
            collectedItems++;
            Destroy(other.gameObject);
        }
    }
}