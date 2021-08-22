using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] string _itemName;
    public string Name => _itemName;
    public AudioClip _pickupSFX;

    public UnityEvent collected;

    void PlaySound()
    {
        var source = GameState.Instance.GetComponentInChildren<AudioSource>();

        source.PlayOneShot(_pickupSFX);
    }

    void CheckInventory(PlayerInventory playerInv)
    {
        if(playerInv)
        {
            playerInv.Add(this);
            collected?.Invoke();
            PlaySound();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory playerInv = collision.collider.GetComponent<PlayerInventory>();
        CheckInventory(playerInv);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInv = collision.GetComponent<PlayerInventory>();
        CheckInventory(playerInv);
    }
}
