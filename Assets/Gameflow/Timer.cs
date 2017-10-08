using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] int dayDurationInSeconds = 120;

    bool countingDown;
    Text display;
    float timeLeft;

    event Action _onEnd = delegate{};

    public event Action OnEnd
    {
        add { _onEnd += value;}
        remove { _onEnd -= value;}
    }

    void Start()
    {
        display = GetComponent<Text>();
    }

    public void Begin()
    {
        countingDown = true;
        timeLeft = dayDurationInSeconds;
    }

    void Update()
    {
        if (countingDown)
        {
            timeLeft -= Time.deltaTime;
            DisplayTimeLeft();
            if (timeLeft <= 0)
            {
                End();
            }
        }
    }

    void End()
    {
        _onEnd();
        countingDown = false;
    }

    void DisplayTimeLeft()
    {
        int fullSecondsLeft = (int)timeLeft;
        int minutesLeft = fullSecondsLeft / 60;
        int secondsLeftovers = fullSecondsLeft % 60;
        if (secondsLeftovers >= 10)
            display.text = string.Format("{0}:{1}", minutesLeft, secondsLeftovers);
        else
            display.text = string.Format("{0}:0{1}", minutesLeft, secondsLeftovers);
    }
}
