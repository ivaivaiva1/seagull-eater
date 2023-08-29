using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuEater : MonoBehaviour
{

    public int whereJump;

    // Start is called before the first frame update
    void Start()
    {
        whereJump = Random.Range(0,5);
        StartCoroutine("RandomWhere");
    }

    IEnumerator RandomWhere()
    {
      yield return new WaitForSeconds(0.5f);
      whereJump = Random.Range(0,5);
      StartCoroutine("RandomWhere");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -8) * Time.deltaTime);
        if(transform.position.y < 1.620098f)
        {
          if(whereJump == 4 && transform.position.y < 1.6f)
          {
            whereJump = Random.Range(0,5);
            transform.DOMoveY(transform.position.y + 3.5f, 0.3f)
            .SetEase(Ease.OutSine);
          } else
          if(whereJump == 3 && transform.position.y < 0.6f)
          {
            whereJump = Random.Range(0,5);
            transform.DOMoveY(transform.position.y + 3.5f, 0.3f)
            .SetEase(Ease.OutSine);
          } else
          if(whereJump == 2 && transform.position.y < -1.6f)
          {
            whereJump = Random.Range(0,5);
            transform.DOMoveY(transform.position.y + 3.5f, 0.3f)
            .SetEase(Ease.OutSine);
          } else
          if(whereJump == 1 && transform.position.y < -2.6f)
          {
            whereJump = Random.Range(0,5);
            transform.DOMoveY(transform.position.y + 3.5f, 0.3f)
            .SetEase(Ease.OutSine);
          } else
          if(whereJump == 0 && transform.position.y < -3.6f)
          {
            whereJump = Random.Range(0,5);
            transform.DOMoveY(transform.position.y + 3.5f, 0.3f)
            .SetEase(Ease.OutSine);
          } 
        }
    }


    // transform.DOMoveY(transform.position.y + 3.5f, 0.3f)
    // .SetEase(Ease.OutSine);
    //se maior que y 1.620098 dont do
    //se menor que y -3.92 do
}
