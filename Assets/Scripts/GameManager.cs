using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Run,
        Stop,
    }

    public Text _timerText;
    public State state;

    public static GameManager instance;

    private float elapsedTime = 0f; // Time in seconds
    private bool isTimerRunning = false;

    private void Update()
    {
        if (state == State.Run && isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(elapsedTime);
        }
    }

    private void Awake()
    {
        instance = this;
        FindObjectOfType<ButtonToggle>().Init();
        FindObjectOfType<Player>().Init();
    }

    public void StartButtonCallback()
    {
        state = State.Run;
        isTimerRunning = true; // Start or resume the timer
    }

    public void StopButonCallback()
    {
        state = State.Stop;
        isTimerRunning = false; // Pause the timer
    }

    private void UpdateTimerDisplay(float time)
    {
        // Convert time to hours, minutes, seconds
        int hours = Mathf.FloorToInt(time / 3600);  // 1 hour = 3600 seconds
        int minutes = Mathf.FloorToInt((time % 3600) / 60);  // 1 minute = 60 seconds
        int seconds = Mathf.FloorToInt(time % 60);

        // Format the string as "4 hours 12 minutes 12 seconds"
        _timerText.text = string.Format("{0:D2}시간 {1:D2}분 {2:D2}초", hours, minutes, seconds);
    }

    public void InitButtonCallback()
    {

    }
}
