using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButtons : MonoBehaviour
{
    public void Start()
    {

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level One");
    }
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
