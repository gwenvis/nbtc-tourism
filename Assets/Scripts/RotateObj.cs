 using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public GameObject objectToRotate;
 
    private float firstPoint;
    private float secondPoint;
    private int m_inc = 0;

    void Update(){
        if (Input.touchCount == 0)
            {
                m_inc = 0;
                return;
            }
    
    
            if (objectToRotate == null)
            {
                return;
            }

            if (Input.touchCount == 1)
         {  
             if (m_inc==0)
             {
                 firstPoint = (int)Input.GetTouch(0).position.x;
                 secondPoint = (int)Input.GetTouch(0).position.x;
             }
 
             m_inc++;
 
             if (m_inc<=10)
             {
                 return;
             }
 
             secondPoint = (int)Input.GetTouch(0).position.x;
 
             if (firstPoint<secondPoint)
             {
                 Rotate(false);
             }
             else if (firstPoint > secondPoint)
             {
                 Rotate(true);
             }
 
 
             return;
         }
    }

    private void LateUpdate()
     {
         if (m_inc>=10)
         {
             firstPoint = (int)Input.GetTouch(0).position.x;
         }
     }

     private void Rotate(bool right){
        if (right)
                {
                    objectToRotate.transform.Rotate(Vector3.up * Time.deltaTime *200f);
                }
                else
                {
                    objectToRotate.transform.Rotate(Vector3.down * Time.deltaTime *200f);
                }
     }
}
