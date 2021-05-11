using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject SettingsMenu, PlayButton, SettingsButton;
    public Text highscoreText;

    public void PlayGame()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        SettingsMenu.SetActive(true);
        PlayButton.SetActive(false);
        SettingsButton.SetActive(false);
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void CloseSettings()
    {
        SettingsMenu.SetActive(false);
        PlayButton.SetActive(true);
        SettingsButton.SetActive(true);
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
}
