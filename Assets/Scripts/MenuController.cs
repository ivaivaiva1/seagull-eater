using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

   public TextMeshProUGUI bestScoreTXT;
   public TextMeshProUGUI lastScoreTXT;

   void Start()
   {
      Seagull.seagullSpeed = 5f;
      bestScoreTXT.text = ("Best Score: " + PlayerPrefs.GetInt("HighScore").ToString());
      if(Player.points != 0)
      {
       lastScoreTXT.enabled = true;
       lastScoreTXT.text = ("Score: " + Player.points);
      }
      
   }

   public void PlayGame()
   {
    SceneManager.LoadScene("Seagull Eater");
   }
}
