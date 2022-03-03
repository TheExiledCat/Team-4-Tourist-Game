using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private int m_KeysCollected;
    private int m_CheeseCollected;
    private float m_Time;
    private float m_TimeTo;

    private Coroutine m_Stopwatch;
    private Coroutine m_Timer;
    public Action OnTimerFinish;
    public static Gamemanager GM = null;

    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);//Skip this for location since it shouldnt carry to other maps
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCheese()
    {
        m_CheeseCollected++;
    }

    private void InitiateLevel()
    {
    }

    #region Timer

    public void StartTimer(float _t)
    {
        StopAll();
        SetTime(_t);
        m_Timer = StartCoroutine(Timer(m_Time));
    }

    private void StopTimer()
    {
        if (m_Timer != null)
        {
            m_Time = 0;
            StopCoroutine(m_Timer);
            m_Timer = null;
        }
    }

    private IEnumerator Timer(float _t)
    {
        while (m_Time > 0)
        {
            m_Time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_Time = 0;
        StopTimer();
        OnTimerFinish?.Invoke();
        yield break;
    }

    public void StartStopwatch()
    {
        if (m_Stopwatch == null)
        {
            StopAll();
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
        m_Time = 0;
        while (true)
        {
            m_Time += Time.deltaTime;
            print("Timer: " + m_Time);
            yield return new WaitForEndOfFrame();
        }
    }

    public void ResetTime()
    {
        m_Time = 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="_time">Time in seconds</param>
    public void SetTime(float _time)
    {
        m_Time = _time;
    }

    public float GetTime()
    {
        return m_Time;
    }

    private void StopAll()
    {
        if (m_Timer != null)
            StopCoroutine(m_Timer);
        if (m_Stopwatch != null)
            StopCoroutine(m_Stopwatch);
        m_Stopwatch = null;
        m_Timer = null;
    }

    #endregion Timer
}