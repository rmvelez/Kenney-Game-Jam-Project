using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HazardResponse : ScriptableObject
{
    public abstract void OnHazardEnter(HazardDamage damage);
}
