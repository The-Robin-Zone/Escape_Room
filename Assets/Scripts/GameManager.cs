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
    public string PlayerName;

    void Start()
    {
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
        
    }

    void LoadLeaderBoard()
    {
        FirstPlaceName.text = PlayerPrefs.GetString("FirstPlace", "Shaked");
        firstplacetime = PlayerPrefs.GetFloat("FirstPlaceTime", 15.00f);
        FirstPlaceTime.text = firstplacetime.ToString();

        SecondPlaceName.text = PlayerPrefs.GetString("SecondPlace", "Shaked");
        secondplacetime = PlayerPrefs.GetFloat("FirstPlaceTime", 15.00f);
        SecondPlaceTime.text = secondplacetime.ToString();


        ThirdPlaceName.text = PlayerPrefs.GetString("ThirdPlace", "Shaked");
        thirdplacetime = PlayerPrefs.GetFloat("FirstPlaceTime", 15.00f);
        ThirdPlaceTime.text = thirdplacetime.ToString();

    }

    void StartRoom()
    {
        // Start Timer
    }

    void EndRoom()
    {
        // Get timer value
        
        if (CurrentRunScore < firstplacetime)
        {
            PlayerPrefs.SetString("FirstPlace", PlayerName);
            PlayerPrefs.SetFloat("HighScore", CurrentRunScore);
        }
        else if (CurrentRunScore < secondplacetime)
        {
            PlayerPrefs.SetString("SecondPlace", PlayerName);
            PlayerPrefs.SetFloat("HighScore", CurrentRunScore);
        }
        else if (CurrentRunScore < thirdplacetime)
        {
            PlayerPrefs.SetString("ThirdPlace", PlayerName);
            PlayerPrefs.SetFloat("HighScore", CurrentRunScore);
        }

        // play again?
    }

}
