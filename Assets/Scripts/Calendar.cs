using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI clockText;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI weekText;
    [SerializeField] private TextMeshProUGUI monthText;
    [SerializeField] private TextMeshProUGUI seasonText;

    

    private static int minute, hour, day, week, month;

    void Start()
    {
        minute = 0;
        hour = 6;
        day = 1;
        week = 1;
        month = 1;
        
        clockText = transform.Find("clockText").GetComponent<TextMeshProUGUI>();
        dayText = transform.Find("dayText").GetComponent<TextMeshProUGUI>();
        weekText = transform.Find("weekText").GetComponent<TextMeshProUGUI>();
        monthText = transform.Find("monthText").GetComponent<TextMeshProUGUI>();
        seasonText = transform.Find("seasonText").GetComponent<TextMeshProUGUI>();

        CalculateSeason();
    }

    void Update()
    {
        CalculateTime();
        clockText.SetText(hour + ":" + minute); 
        dayText.SetText("Day: " + day);
        weekText.SetText("Week: " + week);
        monthText.SetText("Month: " + month);
    }

    void CalculateSeason()
    {
        if(month == 12 || month == 1 || month == 2)
        {
            seasonText.SetText("Winter");
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

    void CalculateWeek()
    {
        if (day < 7)
        {
            week = 1;
        }
        if (day >= 7 && day < 14)
        {
            week = 2;
        }
         if (day >= 14 && day < 21)
        {
            week = 3;
        }
         if (day >= 21 && day < 28)
        {
            week = 4;
        }
        if (day >= 28)
        {
            week = 5;
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
                week = 1;
                CalculateSeason();
            }
        }

        if(month == 4 || month == 6 || month == 9 || month == 11)
        {
            if (day >= 31)
            {
                month++;
                day = 1;
                week = 1;
                CalculateSeason();
            }
        }
        if(month == 2)
        {
            if (day >= 30)
            {
                month++;
                day = 1;
                week = 1;
                CalculateSeason();
            }    
        }
    }

    void CalculateTime()
    {
        minute += 30;

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
        else if (day >= 7)
        {
            CalculateWeek();
        }
        if (day >= 28)
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
