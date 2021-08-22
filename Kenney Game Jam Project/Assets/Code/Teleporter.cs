using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter other;
    bool isActive = true;

    public void OnRecieveTeleport()
    {
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
            return;

        other.OnRecieveTeleport();
        collision.transform.position = other.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isActive = true;
    }
}
