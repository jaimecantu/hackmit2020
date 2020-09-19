using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public Transform circlePos; // The position of the circle where we will drag the star

    private Vector2 initialPos; // The star's fixed position
    private Vector2 mousePos; // Defines the cursor's position

    private float deltaX, deltaY; // Define offset to make movement more smooth
    public static bool locked; // Becomes true when the star is dropped at a circle

    private void Start()
    {
        initialPos = transform.position; // Initial position is defined by where its placed on the scene at start
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // Updates every frame while left click is being pressed
        {
            if (!locked) // Only allow it to have space to move if the object is unlocked
            {
                deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
                deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            }
        }
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0)) //&& !locked)
        {
            // Translates the cursor's position the screen to a position on the scene that the object can interpret
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // The star's position updates as the cursor is dragged, following it
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // If the star touched and is dropped at a close distance to a circle, lock its position at its center. Otherwise reset.
            if (Mathf.Abs(transform.position.x - circlePos.position.x) <= 1.2f &&
                Mathf.Abs(transform.position.y - circlePos.position.y) <= 1.2f)
            {
                transform.position = new Vector2(circlePos.position.x, circlePos.position.y);
                locked = true;
            }
            else
            {
                transform.position = new Vector2(initialPos.x, initialPos.y);
            }
        }
    }

    /* private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle")) {
            if (other.GetComponent(correctStar);
        }
    }*/
}
