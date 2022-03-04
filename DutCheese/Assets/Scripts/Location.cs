using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField]
    string m_LocationName;
    [SerializeField]
    Character m_Character;
    [SerializeField, TextArea]
    string m_OnStartDialogue;

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

    void Start()
    {
        DialogueSystem.DS.SetDialogue(m_Character, m_OnStartDialogue, 10);
    }

}
