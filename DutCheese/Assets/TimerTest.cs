using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTest : MonoBehaviour
{
    [SerializeField] private TMP_Text m_TextBox;
    private bool started = false;
    [SerializeField] private Button m_Button;

    private void Start()
    {
        m_Button.onClick.AddListener(ToggleStopwatch);
    }

    private void ToggleStopwatch()
    {
        started = !started;
        if (started)
        {
            Gamemanager.GM.StartStopwatch();
        }
        else
        {
            Gamemanager.GM.StopStopwatch();
        }
    }

    private void Update()
    {
        ShowTimeInFormat(Gamemanager.GM.GetTime());
    }

    private void ShowTimeInFormat(float _time)
    {
        float seconds = _time % 60;
        float minutes = Mathf.Floor(_time / 60);
        string text = minutes.ToString("00") + ":" + seconds.ToString("00");
        m_TextBox.text = text;
    }
}