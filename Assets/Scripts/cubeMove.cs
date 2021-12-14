using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cubeMove : MonoBehaviour
{
    float speed = 0.3f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));

        if (transform.position.y >= 1f)
        {
            speed = -0.3f;
        }
        else if (transform.position.y <= 0.7f)
        {
            speed = 0.3f;
        }
    }

}
