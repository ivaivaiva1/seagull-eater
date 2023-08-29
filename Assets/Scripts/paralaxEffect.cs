using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxEffect : MonoBehaviour
{
    
    public float parallaxSize;

    public float parallaxSpeed;

    void Update()
    {
        transform.Translate(new Vector2(-Seagull.seagullSpeed / parallaxSpeed, 0f) * Time.deltaTime);

        if(transform.position.x <= -parallaxSize)
        {
           transform.position = new Vector2(parallaxSize, transform.position.y);
        }
    }
}
