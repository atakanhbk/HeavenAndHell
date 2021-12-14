using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karakterKontrol : MonoBehaviour
{

    public int sevapPoint = 0;

    float distance_to_screen;
    Vector3 pos_move;

    public GameObject pointLight;
    public GameObject pointLightPlayer;
    public GameObject judgePosition;
    public GameObject leftWings;
    public GameObject rightWings;
    public GameObject hare;
    public GameObject leftHorn;
    public GameObject rightHorn;
    public GameObject redLeftWings;
    public GameObject redRightWings;

    public Transform heavenDoor;
    public Transform hellDoor;

    public bool isStart = false;
    bool canClick = true;
    public bool judgeStart = false;


    public Material karakterColor;
 
   
    Animator anim;

    public RawImage clickImage;

    public Text winText;
    public Text loseText;
    public Button startAgain;


    void Start()
    {
        DOTween.Init();
        karakterColor.color = Color.white;
        anim = GetComponent<Animator>();

    
    }

    // Update is called once per frame
    void Update()
    {
        if (judgeStart ==false)
        {
            if (isStart)
            {
                distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
                transform.position = new Vector3(pos_move.x, 0, 0);
            }
        }
  
        if (pos_move.x < -4)
        {
            transform.position = new Vector3(-4, 0, 0);
        }
        if (pos_move.x > 4)
        {
            transform.position = new Vector3(4, 0, 0);
        }

        StartCoroutine(judgeTime());
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            isStart = true;
            anim.SetTrigger("startRun");
            clickImage.gameObject.SetActive(false);
            canClick = false;
        }

        if (sevapPoint == 1)
        {
            leftWings.SetActive(true);
            rightWings.SetActive(false);
            hare.SetActive(false);
            rightHorn.SetActive(false);
            leftHorn.SetActive(false);
            redLeftWings.SetActive(false);
            redRightWings.SetActive(false);
            karakterColor.color = new Color32(175, 255, 175, 255);
        }

        if (sevapPoint==2)
        {
            leftWings.SetActive(true);
            rightWings.SetActive(true);
            hare.SetActive(false);
            rightHorn.SetActive(false);
            leftHorn.SetActive(false);
            redLeftWings.SetActive(false);
            redRightWings.SetActive(false);
            karakterColor.color = new Color32(90, 255, 90, 255);
        }

        if (sevapPoint == 3)
        {
            leftWings.SetActive(true);
            rightWings.SetActive(true);
            hare.SetActive(true);
            rightHorn.SetActive(false);
            leftHorn.SetActive(false);
            redLeftWings.SetActive(false);
            redRightWings.SetActive(false);
            karakterColor.color = new Color32(0, 255, 0, 255);
        }
        if (sevapPoint == 0)
        {
            leftWings.SetActive(false);
            rightWings.SetActive(false);
            hare.SetActive(false);
            rightHorn.SetActive(false);
            leftHorn.SetActive(false);
            redLeftWings.SetActive(false);
            redRightWings.SetActive(false);
            karakterColor.color = new Color32(255, 255, 255, 255);
        }

        if (sevapPoint == -1)
        {
            leftWings.SetActive(false);
            rightWings.SetActive(false);
            hare.SetActive(false);
            rightHorn.SetActive(true);
            leftHorn.SetActive(false);
            redLeftWings.SetActive(false);
            redRightWings.SetActive(false);
            karakterColor.color = new Color32(255, 175, 175, 255);

        }
        if (sevapPoint == -2)
        {
            leftWings.SetActive(false);
            rightWings.SetActive(false);
            hare.SetActive(false);
            rightHorn.SetActive(true);
            leftHorn.SetActive(true);
            redLeftWings.SetActive(false);
            redRightWings.SetActive(false);
            karakterColor.color = new Color32(255, 100, 100, 255);
        }
        if (sevapPoint == -3)
        {
            leftWings.SetActive(false);
            rightWings.SetActive(false);
            hare.SetActive(false);
            rightHorn.SetActive(true);
            leftHorn.SetActive(true);
            redLeftWings.SetActive(true);
            redRightWings.SetActive(false);
            karakterColor.color = new Color32(255, 50, 50, 255);
        }
        if (sevapPoint == -4)
        {
            leftWings.SetActive(false);
            rightWings.SetActive(false);
            hare.SetActive(false);
            rightHorn.SetActive(true);
            leftHorn.SetActive(true);
            redLeftWings.SetActive(true);
            redRightWings.SetActive(true);
            karakterColor.color = new Color32(255, 0, 0, 255);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.tag == "heavenWall")
        {
             karakterColor.color = Color.Lerp(karakterColor.color, Color.green, 0.5f);
            Destroy(other.gameObject);
            sevapPoint++;
            /*
            if (rightWings.activeInHierarchy == true && leftWings.activeInHierarchy==true)
            {
                hare.SetActive(true);
            }
            if (rightWings.activeInHierarchy == true)
            {
                leftWings.SetActive(true);
            }
            if (rightWings.activeInHierarchy == false)
            {
                rightWings.SetActive(true);
            }

            */
        }
        if (other.tag == "heavenDoor")
        {
            karakterColor.color = Color.Lerp(karakterColor.color, Color.green, 0.5f);
            Destroy(other.gameObject);
            sevapPoint++;
  
        }

        if (other.tag == "hellWall")
        {
             karakterColor.color = Color.Lerp(karakterColor.color, Color.red, 0.3f);
            Destroy(other.gameObject);
            /*
            if (hare.activeInHierarchy == false && leftWings.activeInHierarchy == false)
            {
                rightWings.SetActive(false);
            }

            if (hare.activeInHierarchy == true)
            {
                hare.SetActive(false);
            }

            else if (hare.activeInHierarchy ==false && leftWings.activeInHierarchy == true)
            {
                leftWings.SetActive(false);
            }
            if (hare.activeInHierarchy == false && leftWings.activeInHierarchy == false && rightWings.activeInHierarchy == false && rightHorn.activeInHierarchy == true)
            {
                leftHorn.SetActive(true);
            }
            if (hare.activeInHierarchy == false && leftWings.activeInHierarchy ==false && rightWings.activeInHierarchy==false)
            {
                rightHorn.SetActive(true);
            }

            */

          
            sevapPoint--;
        }
        if (other.tag == "doors")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "decisionTime")
        {     
            judgeStart = true;
            pointLight.gameObject.SetActive(true);
            pointLightPlayer.gameObject.SetActive(true);
        }
   
    }

    IEnumerator judgeTime()
    {
        if (judgeStart)
        {
            transform.DOMove(judgePosition.transform.position, 0.5f);
            yield return new WaitForSeconds(0.7f);
            anim.SetTrigger("judgeTime");
        }
    }    
}