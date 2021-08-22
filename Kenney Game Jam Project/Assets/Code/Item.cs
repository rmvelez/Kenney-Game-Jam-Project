using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string _itemName;
    public string Name => _itemName;

    public static event Action<string> collected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory playerInv = collision.collider.GetComponent<PlayerInventory>();

        if(playerInv)
        {
            playerInv.Add(this);
            collected?.Invoke(_itemName);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInv = collision.GetComponent<PlayerInventory>();

        if (playerInv)
        {
            playerInv.Add(this);
            collected?.Invoke(_itemName);
            gameObject.SetActive(false);
        }
    }
}
