using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStar : MonoBehaviour
{
    public GameObject prevCircle;
    private Transform prevCirclePos;

    [HideInInspector]
    public bool starFound; // If a star was dropped correctly, make this true
    private LineRenderer line; // Will draw a line between two stars

    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>(); // Gets the linerenderer component from the circle's gameobject
        prevCirclePos = prevCircle.transform; // Gets the position of the previous circle in the constellation
    }

    private void Update()
    {
        if (starFound) // Draw a connecting line between two stars as long as the previous star was dropped in the correct circle
        {
            if (prevCircle.GetComponent<CheckStar>().starFound == false)
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position);
            } else
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, prevCirclePos.position);
            }
        }
    }
}
