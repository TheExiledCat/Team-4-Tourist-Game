using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    private int m_KeysCollected;
    private int m_CheeseCollected;
    private int m_CheeseLeft;
    private float m_Time = 0;
    private float m_TimeTo;
    private bool m_GameStarted = false;
    private Coroutine m_Stopwatch;
    private Coroutine m_Timer;
    public Action OnTimerFinish;
    public static Gamemanager GM = null;

    public Dictionary<string, InventoryItem> m_Items = new Dictionary<string, InventoryItem>();
    public event Action<Dictionary<string, InventoryItem>> OnItemUpdate;
    public event Action OnTimerStart;
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
        //for testing purpose

        StartTimer(70);
        InitiateLevel();
    }
    private void Update()
    {
        m_CheeseLeft = GameObject.FindObjectsOfType<Cheese>().Length;
        CheckWin();
    }
    public void CollectItem(InventoryItem _item)
    {
        m_Items.Add(_item.m_NameKey, _item);
        string debug = "";
        foreach (KeyValuePair<string, InventoryItem> k in m_Items)
        {
            debug += k.Value.m_NameKey + "\n";
        }
        print(debug);
        OnItemUpdate?.Invoke(m_Items);
    }
    public void RemoveItem(string _nameKey)
    {
        m_Items.Remove(_nameKey);
        OnItemUpdate?.Invoke(m_Items);
    }
    public void CollectCheese()
    {
        m_CheeseCollected++;
    }

    private void InitiateLevel()
    {
        m_CheeseCollected = 0;
        m_KeysCollected = 0;
        m_Items = new Dictionary<string, InventoryItem>();
    }
    private void CheckWin()
    {
        if (m_CheeseLeft == 0)
        {
            WinGame();
        }
    }
    private void WinGame()
    {
        print("Game Won");
    }
    private void LoseGame()
    {
    }
    public bool HasItem(string _itemName)
    {
        if (m_Items.ContainsKey(_itemName))
        {
            return true;
        }
        return false;
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