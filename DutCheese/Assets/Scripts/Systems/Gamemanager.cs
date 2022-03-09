using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private float m_TimeGained = 5, m_Timestart = 70;
    private int m_KeysCollected;
    public int m_CheeseCollected;
    private int m_CheeseLeft;
    private float m_Time = 0;
    private float m_TimeTo;
    [SerializeField]
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

        InitiateLevel();
    }
    private void Update()
    {
        m_CheeseLeft = GameObject.FindObjectsOfType<Cheese>().Length;
        if (m_Time == 0 && m_GameStarted == true)
        {
            LoseGame();
        }
    }
    public void CollectItem(InventoryItem _item)
    {
        m_Items.Add(_item.m_NameKey, _item);
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
        m_Time += m_TimeGained;
    }

    public void InitiateLevel()
    {
        m_CheeseCollected = 0;
        m_KeysCollected = 0;
        StartTimer(m_Timestart);
        m_GameStarted = false;
        m_Items = new Dictionary<string, InventoryItem>();
    }

    public void WinGame()
    {
        print("Game Won");
        //close scene
    }
    private void LoseGame()
    {
        print("Game Lost");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Lose", true);
        m_GameStarted = false;
        Invoke("Reload", 3f);
    }
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        InitiateLevel();
    }
    public void ToggleStart()
    {
        m_GameStarted = !m_GameStarted;
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
            if (m_GameStarted)
            {
                m_Time -= Time.deltaTime;
            }

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