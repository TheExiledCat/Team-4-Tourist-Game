using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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

    bool m_MouseOver = false;
    bool m_Clicked = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_MouseOver = true;
        m_NameText.text = m_LocationName;
        m_SummaryText.text = m_LocationSummary;
        m_PlayButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!m_Clicked)
        {
            m_MouseOver = false;
            m_NameText.text = "";
            m_SummaryText.text = "";
            m_PlayButton.SetActive(false);
        }
        else
        {
            m_NameText.text = m_LocationName;
            m_SummaryText.text = m_LocationSummary;
            m_PlayButton.SetActive(true);
        }
    }

    public void SelectLevel()
    {
        Debug.Log("clicked");
        m_MapSelection.SetSelectedScene(m_LocationName);
        m_Clicked = true;
    }
}
