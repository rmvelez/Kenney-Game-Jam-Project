using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazard Response/Player Death")]
public class PlayerDeathResponse : HazardResponse
{
    public override void OnHazardEnter(HazardDamage damage)
    {
        Die(damage);
    }

    void Die(HazardDamage d)
    {
        var player = d.GetComponent<PlayerMovement>();
        player.Die();
    }
}
