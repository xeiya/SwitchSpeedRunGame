using UnityEngine;

public class CollectSouls : MonoBehaviour
{
    public int collectedSouls;
    public int requiredSouls;
    public EndBarrier endBarrier;

    public string collectableTag = "PickUp";

    void Update()
    {
        if (collectedSouls == requiredSouls) 
        { 
            endBarrier.DestroyGate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collectableTag)
        {
            collectedSouls++;
            Destroy(other.gameObject);
        }
    }
}