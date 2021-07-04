using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calendar : MonoBehaviour
{

    private const int TIMESCALE = 60;

    [SerializeField] TextMeshProUGUI clockText;
    [SerializeField] TextMeshProUGUI dayText;
    //[SerializeField] TextMeshProUGUI weekText;
    [SerializeField] TextMeshProUGUI monthText;
    [SerializeField] TextMeshProUGUI seasonText;

    private static double minute, hour, day, week, month, season;

    void Start()
    {
        clockText = GetComponentInChildren<TextMeshProUGUI>();
        dayText = GetComponentInChildren<TextMeshProUGUI>();
        //weekText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        monthText = GetComponentInChildren<TextMeshProUGUI>();
        seasonText = GetComponentInChildren<TextMeshProUGUI>();
        
        minute = 0;
        hour = 6;
        day = 1;
        //week = 1;
        month = 1;
        season = 1;

        
    }

    void Update()
    {
        CalculateTime();
        clockText.SetText(hour + ":" + minute); 
        dayText.SetText("Day: " + day);
        //weekText.SetText("Week: " + week);
        monthText.SetText("Month: " + month);
        seasonText.SetText("Season: " + season);
    }

    void CalculateSeason()
    {
        if(month == 12 || month == 1 || month == 2)
        {
            seasonText.text = "Winter";
        }
         if(month == 3 || month == 4 || month == 5)
        {
            seasonText.text = "Spring";
        }
         if(month == 6 || month == 7 || month == 8)
        {
            seasonText.text = "Summer";
        }
         if(month == 9 || month == 10 || month == 11)
        {
            seasonText.text = "Autumn";
        }
    }

    void CalculateMonth()
    {
        if(month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if (day >= 32)
            {
                month++;
                day = 1;
                CalculateSeason();
            }
        }

        if(month == 4 || month == 6 || month == 9 || month == 11)
        {
            if (day >= 31)
            {
                month++;
                day = 1;
                CalculateSeason();
            }
        }
        if(month == 2)
        {
            if (day >= 30)
            {
                month++;
                day = 1;
                CalculateSeason();
            }    
        }
    }

    void CalculateTime()
    {
        minute += Time.deltaTime * TIMESCALE;

        if (minute >= 60)
        {
            hour++;
            minute = 0;
        }
        else if (hour >= 24)
        {
            day++;
            hour = 0;
        }
        else if (day >= 28)
        {
            CalculateMonth();
        }
        else if (month > 12)
        {
            month = 1;
            CalculateSeason();
        }
    }
}
