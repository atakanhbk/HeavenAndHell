using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startAgain : MonoBehaviour
{

    public void startAgainFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
