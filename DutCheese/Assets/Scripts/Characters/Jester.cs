using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : Character
{
    [SerializeField]
    private GameObject m_Cheese;
    [SerializeField]
    private Character m_RatKing;
    [SerializeField]
    private GameObject m_Key;
    private Animator m_Anim;
    [SerializeField]
    private Item m_RequiredItem;
    private InventoryItem m_RequiredInventoryItem;

    private void Start()
    {
        m_Anim = GetComponent<Animator>();
        OnClick.AddListener(KillJester);
        m_RequiredInventoryItem = new InventoryItem(m_RequiredItem.GetItem().m_NameKey, m_RequiredItem.GetItem().m_Image);
    }

    public void KillJester()
    {
        if (Gamemanager.GM.HasItem(m_RequiredInventoryItem.m_NameKey))
        {
            m_Anim.SetBool("death", true);
            m_Cheese.SetActive(true);
            Invoke("ActivateKey", 2f);
        }
    }
    private void ActivateKey()
    {
        m_Key.SetActive(true);
        DialogueSystem.DS.SetDialogue(m_RatKing, "That was quite amusing, here have my shit", 7);
    }
}