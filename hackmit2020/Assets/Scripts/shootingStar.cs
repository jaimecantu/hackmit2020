using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingStar : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 position;
    float initialX, initialY;
    void Start()
    {
        position = transform.position;
        initialX = transform.position.x;
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += 1f;
        position.y -= 1f;

        transform.position = position;

        if(position.x >= 855f||position.y <= -533)
        {
            position.x = initialX;
            position.y = initialY;
            transform.position = position;
            //System.Threading.Thread.Sleep(1000);

        }
    }
}
