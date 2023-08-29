using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{

    //     ----------------------------  Balance Vars
    public int maxHungry = 100;
    public static float currentHungry;
    public static float HungerDecay;
    public float spawnTime;
    public static float playerFeed;
    public int randomSpawnINT;

    //  -------------------------------- UI

    public TextMeshProUGUI scoreTXT;
    public Image healthBar;
  

    // --------------------------- Game Objects

    public List<Transform> spawnPoints;
    public GameObject seagullOBJ;

    public void Pause()
    {
      if(Time.timeScale == 0)
      {
        Time.timeScale = 1;
      } else
      if(Time.timeScale == 1)
      {
        Time.timeScale = 0;
      }   
    }

    // Start is called before the first frame update
    void Start()
    {
      currentHungry = maxHungry;
      StartCoroutine("StartGame");
    }

    void Update() 
    {
      UIvoid();
      Balancing();
      randomSpawnINT = Random.Range(0,5);
      currentHungry = currentHungry - HungerDecay * Time.deltaTime;
      if(currentHungry > 100f)
      {
        currentHungry = 100f;
      } else
      if(currentHungry < 0f)
      {
        currentHungry = 0f;
      }
    }

    void Balancing()
    {
      if(Player.points <= 100)
      {
        spawnTime = 1.5f - (Player.points / 100f);
        Seagull.seagullSpeed = 5f + (Player.points / 5f);
        playerFeed = 15f - (Player.points / 60f);
        HungerDecay = 8f + (Player.points / 12f);
      } else
      if(Player.points <= 150)
      {
        Seagull.seagullSpeed = 5f + (Player.points / 5f);
        playerFeed = 15f - (Player.points / 50f);
        HungerDecay = 8f + (Player.points / 10f);
      }
    }

    void UIvoid()
    {
      healthBar.fillAmount = currentHungry / maxHungry;
      scoreTXT.text = Player.points.ToString();
    }

    //                                 Seagull Spawner
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine("StartGame");
        yield return new WaitForSeconds(Random.Range(0.1f,1f));
        Instantiate(seagullOBJ, spawnPoints[randomSpawnINT].position, Quaternion.identity);
    }

}
