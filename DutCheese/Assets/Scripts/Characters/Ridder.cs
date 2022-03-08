using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridder : Clickable
{
    [SerializeField] private int m_CheeseVisibleStart = 3;
    private Animator m_Anim;
    [SerializeField] private Item m_Scissor;
    // Start is called before the first frame update
    private void Start()
    {
        OnClick.AddListener(CheckCheese);
        m_Anim = GetComponent<Animator>();
    }

    private void CheckCheese()
    {
        if (Gamemanager.GM.m_CheeseCollected == m_CheeseVisibleStart)
        {
            m_Anim.SetTrigger("Open");
            m_Scissor.gameObject.SetActive(true);
        }
    }
}