using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDamage : MonoBehaviour
{
    public LayerMask hazardLayers;
    public List<HazardResponse> responses;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherCollider.IsTouchingLayers(hazardLayers))
        {
            foreach (HazardResponse r in responses)
            {
                r.OnHazardEnter(this);
            }
        }
    }
}
