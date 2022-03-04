using UnityEngine;

[System.Serializable]
public class Character : Clickable
{
    [SerializeField]
    protected string m_MyName;
    [SerializeField]
    protected Sprite m_Icon;
    [SerializeField]
    string[] m_Dialogues;

    int m_DialogueIndex;

    public string GetName()
    {
        return m_MyName;
    }

    public Sprite GetIcon()
    {
        return m_Icon;
    }

    private void IterateDialogue()
    {
        if (m_DialogueIndex >= m_Dialogues.Length - 1)
        {
            m_DialogueIndex = 0;
        }
        else
        {
            m_DialogueIndex++;
        }
    }

    public void SetNextDialogue()
    {
        var currentCharacter = GetComponent<Character>();
        var nextDialogue = m_Dialogues[m_DialogueIndex];
        DialogueSystem.DS.SetDialogue(currentCharacter, nextDialogue, 5);
        IterateDialogue();
    }
}
