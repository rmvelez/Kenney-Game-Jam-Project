using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] int keysRequired = 1;

    bool isLocked = true;
    Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void Open()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {//Check the player's inventory for the required keys
        PlayerInventory inventory = collision.collider.GetComponent<PlayerInventory>();
        if (!inventory)
            return;

        if(inventory.GetCount("key") >= keysRequired)
        {
            Open();
        }
    }
}
