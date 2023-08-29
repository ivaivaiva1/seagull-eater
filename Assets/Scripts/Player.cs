using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float tweeningForce;

    [SerializeField]
    private float gravityForce;

    public static int points;

    public int howPoints;

    public Animator scoreAnim;
    public Animator playerAnim;
    public GameObject wingsAnim;
    public GameObject wingsAnimRight;

    public static bool isDead = false;

    void Start()
    {
      isDead = false;
      points = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(Controller.currentHungry <= 0)
        {
          scoreAnim.SetBool("isDead", true);
          transform.GetComponent<Collider2D>().enabled = false;
          wingsAnim.GetComponent<Animator>().enabled = false;
          wingsAnimRight.GetComponent<Animator>().enabled = false;
          isDead = true;
          StartCoroutine("callMenu");
          if(PlayerPrefs.GetInt("Highscore") < points)
          {
            PlayerPrefs.SetInt("HighScore", points);
          }
        } 

        if(isDead)
        {
          transform.Translate(new Vector2(0f, -gravityForce * 2) * Time.deltaTime);
        }else
        if(isDead == false)
        {
          transform.Translate(new Vector2(0f, -gravityForce) * Time.deltaTime);
        }
        
       
        if(transform.position.y < -7)
        {
          transform.position = new Vector2(transform.position.x, -7f);
        }
    }

    IEnumerator callMenu()
    {
      yield return new WaitForSeconds(4f);
      SceneManager.LoadScene("Menu");  
    }
 
    public void TweeningX()
    {
      if(isDead == false)
      {
        transform.DOMoveY(transform.position.y + tweeningForce, 0.3f)
        .SetEase(Ease.OutSine);
      }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Seagull") && isDead == false)
        {
           scoreAnim.SetTrigger("bumpScore");
           playerAnim.SetTrigger("eatTrigger");
           points = points + howPoints;
           if(Controller.currentHungry >= 70f)
           {
             Controller.currentHungry = Controller.currentHungry + (Controller.playerFeed / 1.5f);
           } else
           if(Controller.currentHungry >= 30f)
           {
             Controller.currentHungry = Controller.currentHungry + (Controller.playerFeed * 1f);
           } else
           if(Controller.currentHungry <= 30f)
           {
             Controller.currentHungry = Controller.currentHungry + (Controller.playerFeed * 1.5f);
           } 
        }
    }
}
