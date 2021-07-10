using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calendar : MonoBehaviour
{
    /// time variables
    private static int minute, hour, day, week, month;

     /// handles the day slot on the calendar and highlights which one is active.
    #region 
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;

        /// Constructor
        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.dayColor = dayColor;
            this.obj = obj;
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }

        /// Highlights the active day
        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor;
            dayColor = newColor;
        }

        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if(dayColor == Color.white || dayColor == Color.red)
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
    #endregion

    /// List of all days in a month.
    private List<Day> days = new List<Day>();

    /// Holds the week containers.
    public Transform[] weeks;

    /// Text that's printed on the screen.
    public TextMeshProUGUI clockText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI weekText;
    public TextMeshProUGUI monthText;
    public TextMeshProUGUI seasonText; 

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
    /*
    void UpdateMonth(int month)
    {
        
        int startDay = GetMonthStartDay(month);
        int endDay = GetTotalNumberOfDays(month);

        /// Creates days in month
        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay < startDay || currDay - startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey,weeks[w].GetChild(i).gameObject);
                    }
                    else{
                        newDay = new Day(currDay - startDay, Color.white,weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }

        /// Loops through existing days
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if (i < startDay || i - startDay >= endDay)
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }
                days[i].UpdateDay(i - startDay);
            }
        }

        if
    }*/

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
