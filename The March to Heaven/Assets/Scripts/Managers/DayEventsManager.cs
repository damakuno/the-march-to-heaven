using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerations;

public class DayEventsManager : MonoBehaviour
{
    public delegate void OnTimeChange();
    public OnTimeChange onTimeChangeEvents;
    public List<DayEventController> daysList;
    public TimeOfDay currTime { get; private set; }

    // STARTING GAME CONSTANTS
    const string START_MONTH = "March";
    const int START_DATE = 4;
    int numDays;

    GameManager gm;
    VariableUIController varUICtrller;

    void Awake()
    {
        gm = GameManager.Instance;
        gm.onGameStartEvents += StartFirstDay;
    }
    // Start is called before the first frame update
    void Start()
    {
        // init references
        varUICtrller = FindObjectOfType<VariableUIController>();

        // initialise time of day at game start
        currTime = TimeOfDay.MORNING;
        numDays = daysList.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Advances time of day by 1 unit
    /// </summary>
    public void AdvanceTime()
    {
        if (currTime == TimeOfDay.EVENING)
        {
            GoToNextDay();
        }
        else
        {
            currTime++;
        }
        onTimeChangeEvents();
    }

    public void AdvanceTime(int units)
    {
        // check if action takes up more time than what's left in the day
        if (units > 1 && (int)currTime + units > 3)
        {
            // invalid, should not have been able to do this. fire the ui dude.
        }
        else
        {
            currTime += units;
        }
        // TODO
        onTimeChangeEvents();
    }

    public void StartFirstDay()
    {
        gm.currDay += 1;
        currTime = 0;
        daysList[gm.currDay - 1].onDayStart.Invoke();
    }

    public void GoToNextDay()
    {
        // REMEMBER TO USE currDay - 1 because currDay is 1-based
        daysList[gm.currDay - 1].onDayEnd.Invoke();
        // TODO have wait and callback in case the onDayEnd events have a delay or take some visible real playtime to revolve
        gm.currDay += 1;
        currTime = 0;
        daysList[gm.currDay - 1].onDayStart.Invoke();
    }

    public string GetFormattedDate()
    {
        // TODO abstract the starting date out
        int tempd = START_DATE + gm.currDay - 1;
        return tempd + " " + START_MONTH;
    }

    public string GetFormattedDate(int dayNum)
    {
        // TODO abstract the starting date out
        int tempd = START_DATE + dayNum - 1;
        return tempd + " " + START_MONTH;
    }
}
