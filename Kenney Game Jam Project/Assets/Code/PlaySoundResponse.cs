using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazard Response/Play Sound")]
public class PlaySoundResponse : HazardResponse
{
    public AudioClip sound;

    public override void OnHazardEnter(HazardDamage damage)
    {
        AudioSource source = GameState.Instance.GetComponentInChildren<AudioSource>();

        source.PlayOneShot(sound);
    }
}
