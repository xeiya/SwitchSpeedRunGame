using UnityEngine;

public class EndBarrier : MonoBehaviour
{
    [SerializeField] GameObject gateBarrier;

    public void DestroyGate() 
    {
        Destroy(gateBarrier);
    }
}
