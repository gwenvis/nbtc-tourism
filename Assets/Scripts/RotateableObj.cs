using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateableObj : MonoBehaviour
{
    //<summary>
    //This script has to be placed on the object that you want to rotate with touch input.
    //<summary>

    [SerializeField]
    private float rotationSpeed = 0.5f;

    private void Update()
    {
        // get the user touch input
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Moved)
            {

                transform.Rotate(touch.deltaPosition.y * rotationSpeed, -touch.deltaPosition.x * rotationSpeed, 0, Space.World);

            }
        }
    }

}
