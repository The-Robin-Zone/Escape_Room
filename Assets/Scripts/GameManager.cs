using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI CurrentPlayerName;
    public TextMeshProUGUI CurrentPlayerTime;

    // Leader Board 1
    public TextMeshProUGUI FirstPlaceName;
    public TextMeshProUGUI FirstPlaceTime;
    public TextMeshProUGUI SecondPlaceName;
    public TextMeshProUGUI SecondPlaceTime;
    public TextMeshProUGUI ThirdPlaceName;
    public TextMeshProUGUI ThirdPlaceTime;
    public float firstplacetime;
    public float secondplacetime;
    public float thirdplacetime;

    // Leader Board 2
    public TextMeshProUGUI Room2_FirstPlaceName;
    public TextMeshProUGUI Room2_FirstPlaceTime;
    public TextMeshProUGUI Room2_SecondPlaceName;
    public TextMeshProUGUI Room2_SecondPlaceTime;
    public TextMeshProUGUI Room2_ThirdPlaceName;
    public TextMeshProUGUI Room2_ThirdPlaceTime;
    public float Room2_firstplacetime;
    public float Room2_secondplacetime;
    public float Room2_thirdplacetime;

    // Current Run stats
    public float CurrentRunScore;
    public int PlayerName;
    public float timeLimitForRoom = 900.00f;            // 900 second = 15 minutes
    private int RoomChoosen = 0;

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

    public GameObject Nuke;

    void Start()
    {
        CityBackground.Play();
        CityBackground.volume = 0.4f;
        LoadPlayerName();
        SetWatch();
        LoadLeaderBoard_Room1();
        //LoadLeaderBoard_Room2();

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

    void LoadLeaderBoard_Room1()
    {
        FirstPlaceName = GameObject.FindGameObjectWithTag("FirstPlace").GetComponent<TextMeshProUGUI>();
        FirstPlaceTime = GameObject.FindGameObjectWithTag("FirstPlaceTime").GetComponent<TextMeshProUGUI>();
        SecondPlaceName = GameObject.FindGameObjectWithTag("SecondPlace").GetComponent<TextMeshProUGUI>();
        SecondPlaceTime = GameObject.FindGameObjectWithTag("SecondPlaceTime").GetComponent<TextMeshProUGUI>();
        ThirdPlaceName = GameObject.FindGameObjectWithTag("ThirdPlace").GetComponent<TextMeshProUGUI>();
        ThirdPlaceTime = GameObject.FindGameObjectWithTag("ThirdPlaceTime").GetComponent<TextMeshProUGUI>();

        FirstPlaceName.text = "Roni"; //PlayerPrefs.GetString("FirstPlace", "Unranked");
        firstplacetime = PlayerPrefs.GetFloat("FirstPlaceTime", timeLimitForRoom);
        FirstPlaceTime.text = "15:00"; // firstplacetime.ToString();

        SecondPlaceName.text = PlayerPrefs.GetString("SecondPlace", "Unranked");
        secondplacetime = PlayerPrefs.GetFloat("SecondPlaceTime", timeLimitForRoom);
        SecondPlaceTime.text = secondplacetime.ToString();


        ThirdPlaceName.text = PlayerPrefs.GetString("ThirdPlace", "Unranked");
        thirdplacetime = PlayerPrefs.GetFloat("ThirdPlaceTime", timeLimitForRoom);
        ThirdPlaceTime.text = thirdplacetime.ToString();

    }

    //void LoadLeaderBoard_Room2()
    //{
    //    Room2_FirstPlaceName = GameObject.FindGameObjectWithTag("Room2_FirstPlace").GetComponent<TextMeshProUGUI>();
    //    Room2_FirstPlaceTime = GameObject.FindGameObjectWithTag("Room2_FirstPlaceTime").GetComponent<TextMeshProUGUI>();
    //    Room2_SecondPlaceName = GameObject.FindGameObjectWithTag("Room2_SecondPlace").GetComponent<TextMeshProUGUI>();
    //    Room2_SecondPlaceTime = GameObject.FindGameObjectWithTag("Room2_SecondPlaceTime").GetComponent<TextMeshProUGUI>();
    //    Room2_ThirdPlaceName = GameObject.FindGameObjectWithTag("Room2_ThirdPlace").GetComponent<TextMeshProUGUI>();
    //    Room2_ThirdPlaceTime = GameObject.FindGameObjectWithTag("Room2_ThirdPlaceTime").GetComponent<TextMeshProUGUI>();

    //    Room2_FirstPlaceName.text = PlayerPrefs.GetString("Room2_FirstPlace", "Unranked");
    //    Room2_firstplacetime = PlayerPrefs.GetFloat("Room2_FirstPlaceTime", timeLimitForRoom);
    //    Room2_FirstPlaceTime.text = firstplacetime.ToString();

    //    Room2_SecondPlaceName.text = PlayerPrefs.GetString("Room2_SecondPlace", "Unranked");
    //    Room2_secondplacetime = PlayerPrefs.GetFloat("Room2_SecondPlaceTime", timeLimitForRoom);
    //    Room2_SecondPlaceTime.text = secondplacetime.ToString();


    //    Room2_ThirdPlaceName.text = PlayerPrefs.GetString("Room2_ThirdPlace", "Unranked");
    //    Room2_thirdplacetime = PlayerPrefs.GetFloat("Room2_ThirdPlaceTime", timeLimitForRoom);
    //    Room2_ThirdPlaceTime.text = thirdplacetime.ToString();

    //}

    public void StartButton()
    {
        RocketWhistle.Play();
        RocketWhistle.volume = 1;
        Sirens.Play();
        Sirens.volume = 1;

        Nuke.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void StartRoom()
    {
        // Start Timer
        RoomStarted = true;

        //if (chooseroom 1){
        //    RoomChoosen = 1;
        //}
        //else
        //{
        //    RoomChoosen = 2;
        //}

        //Change Scene to one of the Rooms

    }

    void EndRoom()
    {
        CurrentRunScore = Timer;
        // Add which room player did so we know which leaderboard to update
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
