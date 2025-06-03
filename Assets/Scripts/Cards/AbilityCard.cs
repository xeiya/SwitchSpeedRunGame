using UnityEngine;

public class AbilityCard : ScriptableObject
{
    public new string name;
    public Sprite artwork;
    public float activeTime;

    public virtual void Activate() { }
}
