using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStar : MonoBehaviour
{
    public GameObject prevCircle; // Defines the position of the previous circle (or tune) in the constellation
    private Transform prevCirclePos;

    [HideInInspector]
    public bool starFound; // If a star was dropped correctly, make this true
    private LineRenderer line; // Will draw a line between two stars

    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        prevCirclePos = prevCircle.transform;
    }

    private void Update()
    {
        if (starFound)
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
