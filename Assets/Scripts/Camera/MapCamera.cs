using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    private Vector3 prevPosition;
    private float prevDistance;
    private readonly float minimalZoom = 12;
    private readonly float maximumZoom = 2;
    void Start()
    {
        prevPosition = Vector3.zero;
        prevDistance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        #if UnityEngine
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            if(prevPosition != Vector3.zero)
            {
                Debug.Log(mousePosition);
                Vector3 position = prevPosition - new Vector3(mousePosition.x, prevPosition.y, mousePosition.y);
                transform.localPosition = transform.localPosition + position/100;
            }
            prevPosition = new Vector3(mousePosition.x, prevPosition.y, mousePosition.y);


        }
        else
        {
            prevPosition = Vector3.zero;
        }
        #else
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                Vector3 position = prevPosition - new Vector3(pos.x, prevPosition.y, pos.y);
                // Position the cube.
                if(prevPosition != Vector3.zero)
                {
                    transform.localPosition = transform.localPosition + position/100;
                }
                prevPosition = new Vector3(pos.x, prevPosition.y, pos.y);
            }
        }
        else 
        {
            prevPosition = Vector3.zero;
        }
        
        if(Input.touchCount > 1)
        {
            Vector2 firstInput = Input.GetTouch(0).position;
            Vector2 secondInput = Input.GetTouch(1).position;
            float distance = Vector2.Distance(firstInput, secondInput);
            if(prevDistance != 0 && ((transform.position.y > maximumZoom && prevDistance - distance < 0) || (transform.position.y < minimalZoom && prevDistance - distance > 0)))
            {
              float difference = distance - prevDistance;
              transform.position += transform.forward * (difference/100);
            }

            if(transform.position.y < maximumZoom)
            {
                transform.position= new Vector3(transform.position.x, maximumZoom, transform.position.z);
                prevDistance = 0;
            }

            if(transform.position.y > minimalZoom)
            {
                transform.position= new Vector3(transform.position.x, maximumZoom, transform.position.z);
                prevDistance = 0;
            }

            prevDistance = distance;
        }
        else
        {
            prevDistance = 0;
        }
        #endif
    }
}