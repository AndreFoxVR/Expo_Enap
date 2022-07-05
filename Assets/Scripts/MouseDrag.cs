using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;

public class MouseDrag : MonoBehaviour
{
    [Flags]


    public enum RotationDirection
    {
        None,
        Horizontal = (1 << 0),
        Vertical = (1 << 1)
    }
    [Tooltip("Which directions this objects rotate")]
    [SerializeField] private RotationDirection rotationDirections;
    [SerializeField] private Vector2 acceleration;
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private float inputLagPeriod;
    [SerializeField] private float maxVerticalAngleFromHorizon;

    private Vector2 velocity;
    private Vector2 rotation;
    private Vector2 lastinputEvent;
    private float inputLagTimer;
    public float speed = 5f;
    private void OnEnable()
    {
        velocity = Vector2.zero;
        inputLagTimer = 0;
        lastinputEvent = Vector2.zero;
        Vector3 euler = transform.localEulerAngles;
        if (euler.x >= 180)
        {
            euler.x -= 360;
        }
        euler.x = ClampVerticalAngle(euler.x);
        transform.localEulerAngles = euler;
        rotation = new Vector2(euler.y, euler.x);
    }
    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalAngleFromHorizon, maxVerticalAngleFromHorizon);

    }
    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime;
        Vector2 input = new Vector2
            (Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"));
        if ((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastinputEvent = input;
            inputLagTimer = 0;
        }
        return lastinputEvent;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += speed * new Vector3(x: -Input.GetAxis("Mouse Y"), y: Input.GetAxis("Mouse X"), z: 0);
            Debug.Log(transform.position);
        }
    }
    //___TESTES

    //static void Reset()
    //{
    //    if (SceneView.lastActiveSceneView != null)
    //    {
    //        MethodInfo info = SceneView.lastActiveSceneView.GetType().
    //            GetMethod("OnNewProjectLayoutWasCreated", BindingFlags.Instance | BindingFlags.NonPublic);
    //        info.Invoke(SceneView.lastActiveSceneView, null);
    //    }
    //}

   
    

    //private void Update()
    //    {
    //        Vector2 wantedVelocity = GetInput() * sensitivity;

    //        if((rotationDirections & RotationDirection.Horizontal) == 0)
    //        {
    //            wantedVelocity.x = 0;
    //        }
    //        if((rotationDirections & RotationDirection.Vertical) == 0)
    //        {
    //            wantedVelocity.y = 0;
    //        }

    //        velocity = new Vector2(
    //            Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
    //        Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime));
    //        rotation += velocity * Time.deltaTime;
    //        rotation.y = ClampVerticalAngle(rotation.y);

    //        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    //    }
}