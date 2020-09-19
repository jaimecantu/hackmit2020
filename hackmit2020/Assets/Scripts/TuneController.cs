using UnityEngine;
using System.Collections;

public class TuneController : MonoBehaviour
{
    public AudioSource tunes; // Creates an audio player
    public AudioClip gNote; // Fetches a particular clip / file

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            tunes.PlayOneShot(gNote); // Plays one instance of the clip specified
        }
    }
}
