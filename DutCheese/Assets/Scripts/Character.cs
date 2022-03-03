using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    [SerializeField]
    protected string m_MyName;
    [SerializeField]
    protected Sprite m_Icon;
    [SerializeField]
    string[] m_Dialogues;

    public string GetName()
    {
        return m_MyName;
    }

    public Sprite GetIcon()
    {
        return m_Icon;
    }
}
