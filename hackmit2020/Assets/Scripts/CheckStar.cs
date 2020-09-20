using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStar : MonoBehaviour
{
    public GameObject prevCircle;
    private Transform prevCirclePos;

    [HideInInspector]
    public bool starFound; // If a star was dropped correctly, make this true
    [HideInInspector]
    public bool allStarsFound; // Checks if level is complete if all stars were placed correctly
    private LineRenderer line; // Will draw a line between two stars

    public bool isThisEnd = false;
    public AudioSource tunes;
    public StarController[] noteSequence;

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

                if (isThisEnd)
                {
                    allStarsFound = true;
                    for (int i = 0; i < noteSequence.Length; i++)
                    {
                        if (!noteSequence[i].GetComponent<StarController>().locked)
                        {
                            allStarsFound = false;
                        }
                    }
                    if (allStarsFound)
                    {
                        StartCoroutine(PlaySong());
                        isThisEnd = false;
                    }
                    
                }
            }
        }
    }

    IEnumerator PlaySong()
    {
        yield return new WaitForSeconds(0.8f);

        // !!! This object's AudioSource needs the clip "levelComplete" if isThisEnd is true !!!
        tunes.Play();
        yield return new WaitForSeconds(1.2f);
        tunes.Stop();

        // Loop source: https://stackoverflow.com/questions/43715482/play-several-audio-clips-sequentially
        //1.Loop through each AudioClip
        for (int i = 0; i < noteSequence.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            tunes.clip = noteSequence[i].GetComponent<AudioSource>().clip;

            //3.Play Audio
            noteSequence[i].GetComponent<Animator>().SetBool("playing", true); // Star moves while sound plays
            tunes.Play();

            //4.Wait for it to finish playing
            while (tunes.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
            noteSequence[i].GetComponent<Animator>().SetBool("playing", false); // Stop the star's animation
        }
    }
}
