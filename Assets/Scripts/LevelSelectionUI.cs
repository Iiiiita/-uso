using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelSelectionUI : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameManager gameManager;
    public Text level1score;
    float levelOneScore;
    float levelOneHighscore;
    float tempHighscore = 0;
    float check;

    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(false);
        levelOneScore = PlayerPrefs.GetFloat("score");
        check = PlayerPrefs.GetFloat("levelOneHighScore");
     
        if (levelOneScore > check)
        {
            levelOneHighscore = levelOneScore;
            tempHighscore = PlayerPrefs.GetFloat("levelOneHighScore", 0);
            PlayerPrefs.SetFloat("levelOneHighScore", levelOneHighscore);
            levelOneScore = tempHighscore;
        }
        levelOneHighscore = PlayerPrefs.GetFloat("levelOneHighScore");
        level1score.text = "Score: " + levelOneHighscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSettingsButtonClick()
    {
        SettingsPanel.SetActive(true);
    }

    public void OnExitButtonClick()
    {
        SettingsPanel.SetActive(false);
    }

    public void OnPlayLevelOneButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    public void OnBackButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnEasyButtonClick()
    {
        Debug.Log("Easy difficulty level");
    }

    public void OnMediumButtonClick()
    {
        Debug.Log("Medium difficulty level");
    }

    public void OnHardButtonClick()
    {
        Debug.Log("Hard difficulty level");
    }
}
