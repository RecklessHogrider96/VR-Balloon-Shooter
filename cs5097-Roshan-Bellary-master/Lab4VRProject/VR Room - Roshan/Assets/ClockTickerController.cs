using System;
using UnityEngine;

public class ClockTickerController : MonoBehaviour
{
    [Header("Clock Hands")]
    [SerializeField] private GameObject HoursHand;
    [SerializeField] private GameObject MinutesHand;
    [SerializeField] private GameObject SecondsHand;

    private DateTime CurrentTime;

    private void Start()
    {
        CurrentTime = DateTime.Now;

        SetCurrentTime();
    }

    void Update()
    {
        SetTime();
    }

    private void SetCurrentTime()
    {
        HoursHand.transform.Rotate(Vector3.right, 360 / 30 * CurrentTime.Hour);
        MinutesHand.transform.Rotate(Vector3.right, 360 / 6 * CurrentTime.Minute);
        SecondsHand.transform.Rotate(Vector3.right, 360 / 6 * CurrentTime.Second);
    }

    private void SetTime()
    {
        // Set Hours Hand, iff new hours is different that before.
        if (CurrentTime.Hour != DateTime.Now.Hour)
        {
            HoursHand.transform.Rotate(Vector3.right, 30);
        }

        // Set Minutes Hand
        if (CurrentTime.Minute != DateTime.Now.Minute)
        {
            MinutesHand.transform.Rotate(Vector3.right, 6);
        }

        // Set Seconds Hand
        if (CurrentTime.Second != DateTime.Now.Second)
        {
            SecondsHand.transform.Rotate(Vector3.right, 6);
        }

        CurrentTime = DateTime.Now;
    }
}
