using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public int collectedItems;
    public int requiredItems = 3;

    public string collectableTag = "PickUp";

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collectableTag)
        {
            collectedItems++;
            Destroy(other.gameObject);
        }
    }
}