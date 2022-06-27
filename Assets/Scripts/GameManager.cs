using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider scoreIndicator;
    public BeatScroller theBS;
    public static GameManager instance;
    public GameObject x2Multiplier;
    public GameObject x4Multiplier;
    public GameObject x8Multiplier;
    public GameObject x16Multiplier;
    private int currentScore;

    public int CurrentScore
    {
        get { return currentScore; }
        set 
        {
            currentScore = value;
            scoreIndicator.value = currentScore;
            scoreText.text = (scoreIndicator.value).ToString("000");
        }
    }

    public int scorePerNote = 100;
    //public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int Multiplier;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentMultiplier = 1;
        Multiplier = 1;
        x2Multiplier.SetActive(false);
        x4Multiplier.SetActive(false);
        x8Multiplier.SetActive(false);
        x16Multiplier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NoteHit()
    {

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
                Multiplier *= 2;
            }
        }

        if(Multiplier == 2)
        {
            x2Multiplier.SetActive(true);
        }

        if(Multiplier == 4)
        {
            x2Multiplier.SetActive(false);
            x4Multiplier.SetActive(true);
        }

        if (Multiplier == 8)
        {
            x4Multiplier.SetActive(false);
            x8Multiplier.SetActive(true);
        }

        if (Multiplier == 16)
        {
            x8Multiplier.SetActive(false);
            x16Multiplier.SetActive(true);
        }
    }

    public void NormalHit()
    {
        NoteHit();
        CurrentScore += scorePerNote * Multiplier;
        Debug.Log("normal hit");
    }

    /*public void GoodHit()
    {
        CurrentScore += scorePerGoodNote * Multiplier;
        NoteHit();
    }*/

    public void PerfectHit()
    {
        NoteHit();
        CurrentScore += scorePerPerfectNote * Multiplier;
        Debug.Log("perfect!");
    }

    public void NoteMissed()
    {
       
        Debug.Log("MISSED NOTE!");
        currentMultiplier = 1;
        Multiplier = 1;
        multiplierTracker = 0;

        x2Multiplier.SetActive(false);
        x4Multiplier.SetActive(false);
        x8Multiplier.SetActive(false);
        x16Multiplier.SetActive(false);
    }

}
