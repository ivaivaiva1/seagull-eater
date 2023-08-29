using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    public float timetoDestroy;

    void Start()
    {
        Destroy(gameObject, timetoDestroy);
    }

    void Update() 
    {
        transform.Translate(new Vector2(-Seagull.seagullSpeed, 0f) * Time.deltaTime);
    }
}
