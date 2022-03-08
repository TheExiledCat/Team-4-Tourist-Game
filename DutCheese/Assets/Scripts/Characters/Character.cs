using UnityEngine;

[System.Serializable]
public class Character : Clickable
{
    [SerializeField]
    protected string m_MyName;
    [SerializeField]
    protected Sprite m_Icon;
    [SerializeField, TextArea]
    private string[] m_Dialogues;

    private int m_DialogueIndex;

    private void Start()
    {
        OnClick.AddListener(SetNextDialogue);
    }
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
        if (m_Dialogues.Length > 0)
        {
            var currentCharacter = this;
            var nextDialogue = m_Dialogues[m_DialogueIndex];
            DialogueSystem.DS.SetDialogue(currentCharacter, nextDialogue, 5);
            IterateDialogue();
        }
    }
}