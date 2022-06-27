using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    private float timeRemaining;
    public bool timerIsRunning = false;
    public bool isGameCompleted = false;
    public GameObject SettingsPanel;
    public GameObject EndScreen;
    public Text timeText;
    public Slider timer;

    public GameManager gameManager;
    public Text scoreText;
    public Text completeText;
    public VolumeSettings volumeSettings;

    private Image soundsImage;
    private Image musicImage;
    public Sprite muteImage;
    public Sprite soundsOnImage;
    public Button soundsButton;
    public Button musicButton;

    public float TimeRemaining
    {
        get { return timeRemaining; }
        set
        {
            timeRemaining = value;
            timer.value = timeRemaining;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(false);
        EndScreen.SetActive(false);
        timerIsRunning = true;

        TimeRemaining = 57;

        soundsImage = soundsButton.GetComponent<Image>();
        musicImage = musicButton.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                DisplayTime(TimeRemaining);
            }
            else
            {
                Debug.Log("Timeout");
                TimeRemaining = 0;
                isGameCompleted = true;
                timerIsRunning = false;
                GameCompleted();
            }
        }

        if (volumeSettings.musicSlider.value == volumeSettings.musicSlider.minValue)
        {
            musicImage.sprite = muteImage;
        }
        else
        {
            musicImage.sprite = soundsOnImage;
        }

        if (volumeSettings.soundsSlider.value == volumeSettings.soundsSlider.minValue)
        {
            soundsImage.sprite = muteImage;
        }
        else
        {
            soundsImage.sprite = soundsOnImage;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Pressing the settings button opens the setting panel.
    public void OnSettingsButtonClick()
    {
        SettingsPanel.SetActive(true);
        Time.timeScale = 0;
        volumeSettings.musicSource.Pause();
       
    }

    public void OnExitButtonClick()
    {
        SettingsPanel.SetActive(false);
        Time.timeScale = 1;
        volumeSettings.musicSource.Play();
        
    }

    public void OnNextButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnBackButtonClick()
    {
        Time.timeScale = 1;
        volumeSettings.musicSource.Play();
        SceneManager.LoadScene(1);
    }

    public void GameCompleted()
    {
        EndScreen.SetActive(true);
        scoreText.text = "Score: " + gameManager.CurrentScore;

        PlayerPrefs.SetFloat("score", gameManager.CurrentScore);
        if(gameManager.CurrentScore < 52000)
        {
            completeText.text = "Might need some practice...";
        }
        else if (gameManager.CurrentScore >= 52000 && gameManager.CurrentScore < 73000)
        {
            completeText.text = "Nicely done";
        }
        else if (gameManager.CurrentScore >= 73000 && gameManager.CurrentScore < 94000)
        {
            completeText.text = "Great job!";
        }
        else
            completeText.text = "Perfect!";
    }
}
