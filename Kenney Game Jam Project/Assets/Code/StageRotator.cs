using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StageRotator : MonoBehaviour
{
    PlayerInput _input;
    public float interval = 90;
    public float rotateTime = 0.5f;
    bool _isRotating;
    float _targetRotation;

    public event Action<float> rotated;

    private void Awake()
    {
        _input = FindObjectOfType<PlayerInput>();
    }

    void Start()
    {
        _input.onActionTriggered += (ctx) => { if (ctx.action.name == "RotateCW") RotateCW(ctx); };
        _input.onActionTriggered += (ctx) => { if (ctx.action.name == "RotateCCW") RotateCCW(ctx); };
    }

    private void RotateCW(InputAction.CallbackContext context)
    {
        if(context.started && !_isRotating)
        {
            _isRotating = true;

            StartCoroutine(
                DoRotation(1)
                );
        }
    }

    private void RotateCCW(InputAction.CallbackContext context)
    {
        if (context.started && !_isRotating)
        {
            _isRotating = true;

            StartCoroutine(
                DoRotation(-1)
                );
        }
    }

    //Rotates the object based on rotation interval and rotate time
    // dir
    //  1 is Clockwise
    // -1 is CounterClockwise
    private IEnumerator DoRotation(float dir)
    {
        float direction = Mathf.Sign(dir) * -1;
        float start = transform.rotation.eulerAngles.z;
        float target = start + interval * direction;

        float lerpSpd = 1 / rotateTime;
        float t = 0;

        while(t < 1)
        {
            t += lerpSpd * Time.deltaTime;
            var newAngle = Mathf.LerpAngle(start, target, t);
            var rotation = Quaternion.Euler(0, 0, newAngle);

            rotated?.Invoke(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, newAngle));

            transform.rotation = rotation;

            yield return null;
        }
        _isRotating = false;
    }

    void Update()
    {
        if(_isRotating)
        {
            //Apply lerp
            
        }
    }
}
