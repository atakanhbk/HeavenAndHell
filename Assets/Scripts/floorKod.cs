using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorKod : MonoBehaviour
{
    GameObject karakterKontrol;
    karakterKontrol kontrol;
    int floorSpeed = 0;

    void Start()
    {
        karakterKontrol = GameObject.FindGameObjectWithTag("Player");
        kontrol = karakterKontrol.GetComponent<karakterKontrol>();

      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, floorSpeed * Time.deltaTime * 3));
        StartCoroutine(stop());
        if (kontrol.isStart)
        {
            if (kontrol.judgeStart == false)
            {
                floorSpeed = -2;
            }  
        }
    }

    IEnumerator stop()
    {
        if (kontrol.judgeStart == true)
        {
            yield return new WaitForSeconds(0.7f);
            floorSpeed = 0;
        }
    }
}
