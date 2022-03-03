using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField]
    string m_LocationName;
    [SerializeField]
    Character m_RatKing;
    [SerializeField]
    string m_OnStartDialogue;

    public static Location LC = null;
    DialogueSystem m_DialogueSystem;

    private void Awake()
    {
        if(LC == null)
        {
            LC = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        m_DialogueSystem.SetDialogue(m_RatKing, m_OnStartDialogue, 10);
    }

}
