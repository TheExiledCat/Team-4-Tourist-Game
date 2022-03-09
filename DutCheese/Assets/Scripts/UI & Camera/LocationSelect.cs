using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LocationSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    MapSelection m_MapSelection;

    [SerializeField]
    public string m_LocationName;
    [SerializeField, TextArea]
    string m_LocationSummary;
    [SerializeField]
    TMP_Text m_NameText;
    [SerializeField]
    TMP_Text m_SummaryText;

    [SerializeField]
    GameObject m_PlayButton;
    [SerializeField]
    CanvasGroup m_PlayButtonCanvasGroup;

    [SerializeField]
    Sprite m_UnlockedLevelSprite;
    [SerializeField]
    Image m_LevelImage;
    [SerializeField]
    bool m_LevelUnlocked = false;

    bool m_MouseOver = false;
    bool m_Clicked = false;

    private void Update()
    {
        if (m_LevelUnlocked)
        {
            m_LevelImage.sprite = m_UnlockedLevelSprite;
            m_PlayButton.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_MouseOver = true;
        m_NameText.text = m_LocationName;
        m_SummaryText.text = m_LocationSummary;
        m_PlayButtonCanvasGroup.alpha = 1;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_MouseOver = false;

        if (!m_Clicked)
        {
            m_NameText.text = "";
            m_SummaryText.text = "";
            m_PlayButtonCanvasGroup.alpha = 0;
        }
        else
        {
            m_NameText.text = m_LocationName;
            m_SummaryText.text = m_LocationSummary;
            m_PlayButtonCanvasGroup.alpha = 1;
        }
    }

    public void SelectLevel()
    {
        if (m_LevelUnlocked)
        {
            m_MapSelection.SetSelectedScene(m_LocationName);
            m_Clicked = true;
        }
    }
}
