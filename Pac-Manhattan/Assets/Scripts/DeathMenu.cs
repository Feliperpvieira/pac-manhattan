using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public void restartScene()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
