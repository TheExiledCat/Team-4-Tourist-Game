using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    float m_StandardDuration = 10;
    [SerializeField]
    CanvasGroup m_DialogueBox;
    [SerializeField]
    TMP_Text m_Name;
    [SerializeField]
    Image m_CharacterImage;
    [SerializeField]
    TMP_Text m_Dialogue;

    public static DialogueSystem DS = null;

    private void Awake()
    {
        if (DS == null)
        {
            DS = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ShowDialogueBox()
    {
        m_DialogueBox.alpha = 1;
    }

    private void HideDialogueBox()
    {
        m_DialogueBox.alpha = 0;
    }

    public void SetDialogue(Character _character, string _text, float _duration)
    {
        m_Name.text = _character.GetName();
        m_CharacterImage.sprite = _character.GetIcon();
        m_Dialogue.text = _text;
        ShowDialogueBox();
        Invoke("HideDialogueBox", _duration);
    }
}
