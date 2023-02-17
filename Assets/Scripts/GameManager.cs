using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    // Leader Board
    public TextMeshProUGUI CurrentPlayerName;
    public TextMeshProUGUI CurrentPlayerTime;
    public TextMeshProUGUI FirstPlaceName;
    public TextMeshProUGUI FirstPlaceTime;
    public TextMeshProUGUI SecondPlaceName;
    public TextMeshProUGUI SecondPlaceTime;
    public TextMeshProUGUI ThirdPlaceName;
    public TextMeshProUGUI ThirdPlaceTime;
    public float firstplacetime;
    public float secondplacetime;
    public float thirdplacetime;

    // Current Run stats
    public float CurrentRunScore;
    public int PlayerName;
    public float timeLimitForRoom = 900.00f;            // 900 second = 15 minutes

    // Timer
    public float Timer = 0.0f;
    public bool RoomStarted;
    TimeSpan interval;
    string timeInterval;

    // Sounds
    public AudioSource CityBackground;
    public AudioSource Sirens;
    public AudioSource Bang;
    public AudioSource RocketWhistle;
    public AudioSource RoomBackground;

    void Start()
    {
        CityBackground.Play();

        LoadPlayerName();
        SetWatch();
        //LoadLeaderBoard();

        // Just for testing watch
        StartRoom();
    }


    void Update()
    {
        // Block of code for watch update
        if (RoomStarted == true)
        {
            if (Timer < timeLimitForRoom)
            {
                Timer += Time.deltaTime;
            }
            if (Timer < timeLimitForRoom)
            {
                interval = TimeSpan.FromSeconds(Timer);
                timeInterval = interval.ToString("mm") + ":" + interval.ToString("ss");
                CurrentPlayerTime.text = timeInterval;
            }
        }
    }

    void LoadPlayerName()
    {
        //For testing -  uncomment to reset player name
        //PlayerPrefs.SetInt("PlayerName", 0);

        PlayerName = PlayerPrefs.GetInt("PlayerName", 0);
        PlayerName++;
        PlayerPrefs.SetInt("PlayerName", PlayerName);
    }

    void SetWatch()
    {
        CurrentPlayerName = GameObject.FindGameObjectWithTag("CurrentPlayerName").GetComponent<TextMeshProUGUI>();
        CurrentPlayerTime = GameObject.FindGameObjectWithTag("CurrentPlayerTimer").GetComponent<TextMeshProUGUI>();

        if (PlayerName < 10)
        {
            CurrentPlayerName.text = "#00" + PlayerName.ToString();
        }
        else if (PlayerName < 100)
        {
            CurrentPlayerName.text = "#0" + PlayerName.ToString();
        }
        else if (PlayerName < 1000)
        {
            CurrentPlayerName.text = "#" + PlayerName.ToString();
        }
        else
        {
            //reset players name in PlayerPrefs
            PlayerPrefs.SetInt("PlayerName", 1);
            CurrentPlayerName.text = "#001";

        }

        CurrentPlayerTime.text = Timer.ToString();
    }

    void LoadLeaderBoard()
    {
        FirstPlaceName = GameObject.FindGameObjectWithTag("FirstPlace").GetComponent<TextMeshProUGUI>();
        FirstPlaceTime = GameObject.FindGameObjectWithTag("FirstPlaceTime").GetComponent<TextMeshProUGUI>();
        SecondPlaceName = GameObject.FindGameObjectWithTag("SecondPlace").GetComponent<TextMeshProUGUI>();
        SecondPlaceTime = GameObject.FindGameObjectWithTag("SecondPlaceTime").GetComponent<TextMeshProUGUI>();
        ThirdPlaceName = GameObject.FindGameObjectWithTag("ThirdPlace").GetComponent<TextMeshProUGUI>();
        ThirdPlaceTime = GameObject.FindGameObjectWithTag("ThirdPlaceTime").GetComponent<TextMeshProUGUI>();

        FirstPlaceName.text = PlayerPrefs.GetString("FirstPlace", "Unranked");
        firstplacetime = PlayerPrefs.GetFloat("FirstPlaceTime", timeLimitForRoom);
        FirstPlaceTime.text = firstplacetime.ToString();

        SecondPlaceName.text = PlayerPrefs.GetString("SecondPlace", "Unranked");
        secondplacetime = PlayerPrefs.GetFloat("FirstPlaceTime", timeLimitForRoom);
        SecondPlaceTime.text = secondplacetime.ToString();


        ThirdPlaceName.text = PlayerPrefs.GetString("ThirdPlace", "Unranked");
        thirdplacetime = PlayerPrefs.GetFloat("FirstPlaceTime", timeLimitForRoom);
        ThirdPlaceTime.text = thirdplacetime.ToString();

    }

    void StartRoom()
    {
        // Start Timer
        RoomStarted = true;
    }

    void EndRoom()
    {
        CurrentRunScore = Timer;

        if (CurrentRunScore < firstplacetime)
        {
            PlayerPrefs.SetString("FirstPlace", "#00" + PlayerName.ToString());
            PlayerPrefs.SetFloat("HighScore", CurrentRunScore);
        }
        else if (CurrentRunScore < secondplacetime)
        {
            PlayerPrefs.SetString("SecondPlace", "#00" + PlayerName.ToString());
            PlayerPrefs.SetFloat("HighScore", CurrentRunScore);
        }
        else if (CurrentRunScore < thirdplacetime)
        {
            PlayerPrefs.SetString("ThirdPlace", "#00" + PlayerName.ToString());
            PlayerPrefs.SetFloat("HighScore", CurrentRunScore);
        }

        // congratz message
        // play again?
    }

}
