using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{

    public GameObject bloodAnim;
    public static float seagullSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-seagullSpeed, 0f) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("SeagullKiller"))
        {
           Destroy(this.gameObject);
        } else
        if(other.CompareTag("Player"))
        {
           //call Seagull sound
           Instantiate(bloodAnim, new Vector2(transform.position.x + 0.577f,transform.position.y - 0.46f), Quaternion.identity);
           Destroy(this.gameObject);
        }
    }

}
