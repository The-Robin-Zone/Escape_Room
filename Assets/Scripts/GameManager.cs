using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI FirstPlaceName;
    public TextMeshProUGUI FirstPlaceTime;
    public TextMeshProUGUI SecondPlaceName;
    public TextMeshProUGUI SecondPlaceTime;
    public TextMeshProUGUI ThirdPlaceName;
    public TextMeshProUGUI ThirdPlaceTime;
    public float firstplacetime;
    public float secondplacetime;
    public float thirdplacetime;

    public float CurrentRunScore;
    public int PlayerName;
    public float timeLimitForRoom = 15.00f;

    // Timer
    public float Timer = 0.0f;
    public bool RoomStarted;

    void Start()
    {
        PlayerName = PlayerPrefs.GetInt("PlayerName", 0);
        PlayerName++;
        PlayerPrefs.SetInt("PlayerName", PlayerName);
        FirstPlaceName = GameObject.FindGameObjectWithTag("FirstPlace").GetComponent<TextMeshProUGUI>();
        FirstPlaceTime = GameObject.FindGameObjectWithTag("FirstPlaceTime").GetComponent<TextMeshProUGUI>(); 
        SecondPlaceName = GameObject.FindGameObjectWithTag("SecondPlace").GetComponent<TextMeshProUGUI>(); 
        SecondPlaceTime = GameObject.FindGameObjectWithTag("SecondPlaceTime").GetComponent<TextMeshProUGUI>(); 
        ThirdPlaceName = GameObject.FindGameObjectWithTag("ThirdPlaceTime").GetComponent<TextMeshProUGUI>(); 
        ThirdPlaceTime = GameObject.FindGameObjectWithTag("ThirdPlaceTime").GetComponent<TextMeshProUGUI>();

        LoadLeaderBoard();
        // Add a Function to get the players name
    }


    void Update()
    {
        if (RoomStarted == true)
        {
            if (Timer < timeLimitForRoom)
            {
                Timer += Time.deltaTime;
            }
            if (Timer < timeLimitForRoom)
            {
                // Here I need to update the watch
                Debug.Log(Timer);
            }
        }

    }

    void LoadLeaderBoard()
    {
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
        // Get timer value
        
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

        // play again?
    }

}
