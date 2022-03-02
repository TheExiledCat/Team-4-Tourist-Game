using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private int m_KeysCollected;
    private int m_CheeseCollected;
    private float m_Timer;
    private float m_TimeTo;
    public static Gamemanager GM = null;

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

    private void StartTimer(float _time)
    {
    }
}