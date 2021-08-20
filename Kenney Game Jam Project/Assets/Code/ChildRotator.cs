using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRotator : MonoBehaviour
{
    StageRotator _rotator;

    private void Awake()
    {
        _rotator = GetComponentInParent<StageRotator>();
    }

    void Start()
    {
        _rotator.rotated += OnStageRotate;
    }


    private void OnStageRotate(float dTheta)
    {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - dTheta);
    }
}
