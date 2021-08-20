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

    private void Awake()
    {
        _input = FindObjectOfType<PlayerInput>();
    }

    // Start is called before the first frame update
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
            _targetRotation = transform.rotation.eulerAngles.z + interval;

            StartCoroutine(
                DoRotation(transform.rotation.eulerAngles.z, _targetRotation)
                );
        }
    }

    private void RotateCCW(InputAction.CallbackContext context)
    {
        if (context.started && !_isRotating)
        {
            _isRotating = true;
            _targetRotation = transform.rotation.eulerAngles.z + interval;

            StartCoroutine(
                DoRotation(transform.rotation.eulerAngles.z, _targetRotation)
                );
        }
    }

    private IEnumerator DoRotation(float start, float target)
    {
        float lerpSpd = 1 / rotateTime;
        float t = 0;

        while(t < 1)
        {
            t += lerpSpd * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(start, target, t));
            yield return null;
        }
        _isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRotating)
        {
            //Apply lerp
            
        }
    }
}
