using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private int m_KeysCollected;
    private int m_CheeseCollected;
    private float m_Timer;
    private float m_TimeTo;
    public static Gamemanager GM = null;
    private Coroutine m_Stopwatch;

    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartStopwatch()
    {
        if (m_Stopwatch == null)
        {
            m_Stopwatch = StartCoroutine(Stopwatch());
        }
        else
        {
            Debug.LogWarning("Stopwatch already started");
        }
    }

    public void StopStopwatch()
    {
        if (m_Stopwatch != null)
        {
            print("stopping stopwatch");
            StopCoroutine(m_Stopwatch);
            m_Stopwatch = null;
        }
        ResetTime();
    }

    private IEnumerator Stopwatch()
    {
        m_Timer = 0;
        while (true)
        {
            m_Timer += Time.deltaTime;
            print("Timer: " + m_Timer);
            yield return new WaitForEndOfFrame();
        }
    }

    public void ResetTime()
    {
        m_Timer = 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="_time">Time in seconds</param>
    public void SetTime(float _time)
    {
        m_Timer = _time;
    }

    public float GetTime()
    {
        return m_Timer;
    }
}