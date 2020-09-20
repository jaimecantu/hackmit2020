using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public AudioSource tunes; // Creates an audio player
    public AudioClip note; // Fetches a particular clip / file

    public Transform circlePos; // The position of the circle where we will drag the star

    private Vector2 initialPos; // The star's fixed position
    private Vector2 mousePos; // Defines the cursor's position

    private float deltaX, deltaY; // Define offset to make movement more smooth
    [HideInInspector]
    public bool locked; // Becomes true when the star is dropped at a circle

    private void Start()
    {
        initialPos = transform.position; // Initial position is defined by where its placed on the scene at start
        tunes.clip = note;
    }

    private void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (Input.GetMouseButtonDown(0)) // Updates every frame while left click is being pressed
        {
            if (!locked) // Only allow it to have space to move if the object is unlocked
            {
                deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
                deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            }
        }

        if (Input.GetMouseButtonDown(1)) // If right clicked is pressed over the star, play a sound
        {
            tunes.PlayOneShot(note); // Plays one instance of the clip specified
        }
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && !locked) // Only become dragable if it hasn't been placed correctly yet
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
                locked = true; // Lock position if the star was placed correctly

                // play 'correct star' sound & animation
                tunes.PlayOneShot(note);
                Debug.Log("star was correct");
                circlePos.GetComponent<CheckStar>().starFound = true;
            }
            else
            {
                transform.position = new Vector2(initialPos.x, initialPos.y);
            }
        }
    }
}
