using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionTime : MonoBehaviour
{
    GameObject karakterKontrol;
    karakterKontrol kontrol;
    Animator animDecision;
    void Start()
    {
        karakterKontrol = GameObject.FindGameObjectWithTag("Player");
        kontrol = karakterKontrol.GetComponent<karakterKontrol>();
        animDecision = GetComponent<Animator>();
    }

    
    void Update()
    {
        StartCoroutine(heavenDecision());  
    }

    IEnumerator heavenDecision()
    {
        if (kontrol.judgeStart)
        {
            yield return new WaitForSeconds(4);
            if (kontrol.sevapPoint >=0)
            {
                animDecision.SetTrigger("heavenDecision");
                yield return new WaitForSeconds(2f);
                kontrol.winText.gameObject.SetActive(true);
                kontrol.startAgain.gameObject.SetActive(true);
            }
            else
            {
                animDecision.SetTrigger("hellDecision");
                yield return new WaitForSeconds(2f);
                kontrol.loseText.gameObject.SetActive(true);
                kontrol.startAgain.gameObject.SetActive(true);
            }
        }
    }
}
