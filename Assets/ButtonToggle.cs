using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    public Button _startButton;
    public Button _stopButton;

    public void Init()
    {
        _startButton.onClick.AddListener(GameManager.instance.StartButtonCallback);
        _stopButton.onClick.AddListener(GameManager.instance.StopButonCallback);
        
        _startButton.onClick.AddListener(OnClickStartButton);
        _stopButton.onClick.AddListener(OnClickStopButton);
    }

    public void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);
        _stopButton.gameObject.SetActive(true);
    }
    public void OnClickStopButton()
    {
        _startButton.gameObject.SetActive(true);
        _stopButton.gameObject.SetActive(false);
    }
}
