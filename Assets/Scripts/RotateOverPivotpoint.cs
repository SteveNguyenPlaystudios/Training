using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverPivotpoint : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject pivotObject;


    // Update is called once per frame
    public void Update()
    {
        if (PlayerMovement.facingRight)
        {
            RotateToTheRight();
        }
        if (!PlayerMovement.facingRight)
        {
            RotateToTheLeft();
        }
    }
    

    public void RotateToTheRight()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 0, -1), rotationSpeed * Time.deltaTime);
    }

    public void RotateToTheLeft()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
    }
}
