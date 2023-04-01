using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreenController : MonoBehaviour
{
    public GameObject startGameScreen;
    public void StartGame()
    {
        Debug.Log("Start button pressed");
        SceneManager.LoadScene("SampleScene");
    }
}
