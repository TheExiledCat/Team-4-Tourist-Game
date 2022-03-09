using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField]
    float m_DialogueDuration = 5;
    [SerializeField]
    string m_LocationName;
    [SerializeField]
    Character m_LocationCharacter;
    [SerializeField, TextArea]
    List<string> m_OnStartDialogues;

    int m_DialogueIndex;

    public static Location LC = null;
    
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

    private void IterateDialogue()
    {
        if (m_DialogueIndex != m_OnStartDialogues.Count - 1)
        {
            DialogueSystem.DS.SetDialogue(m_LocationCharacter, m_OnStartDialogues[m_DialogueIndex], m_DialogueDuration);
            m_DialogueIndex++;
            Invoke("IterateDialogue", m_DialogueDuration);
        }
    }

        void Start()
    {
        IterateDialogue();
        Invoke("TogglePlay", m_DialogueDuration * m_OnStartDialogues.Count);
    }

    void TogglePlay()
    {
        Gamemanager.GM.ToggleStart();
    }


}
