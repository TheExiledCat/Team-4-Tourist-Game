using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_Timer, m_Cheese;
    [SerializeField]
    private RectTransform m_InventoryOrigin;
    private float m_Distance = 1920 / 20;
    private float m_ItemWidth = 80, m_ItemHeight = 80;
    // Start is called before the first frame update
    private void Start()
    {
        Gamemanager.GM.OnItemUpdate += ShowInventory;
    }

    private void Update()
    {
        ShowTimeInFormat(Gamemanager.GM.GetTime());
    }

    private void ShowTimeInFormat(float _time)
    {
        float seconds = _time % 60;
        float minutes = Mathf.Floor(_time / 60);
        string text = minutes.ToString("00") + ":" + seconds.ToString("00");
        m_Timer.text = text;
    }
    #region Inventory System
    private void ShowInventory(Dictionary<string, InventoryItem> _items)
    {
        ClearOrigin();
        SpawnInventory(_items);
    }
    private void ClearOrigin()
    {
        foreach (Transform child in m_InventoryOrigin)
        {
            Destroy(child.gameObject);
        }
    }
    private void SpawnInventory(Dictionary<string, InventoryItem> _items)
    {
        int i = 0;
        foreach (KeyValuePair<string, InventoryItem> k in _items)
        {
            GameObject item = new GameObject("Item: " + k.Key);
            RectTransform rt = item.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(m_ItemWidth, m_ItemHeight);
            item.transform.parent = m_InventoryOrigin;
            Image image = item.AddComponent<Image>();
            item.transform.localPosition = Vector2.right * i * m_Distance;
            image.sprite = k.Value.m_Image;
            i++;
        }
    }
    #endregion Inventory System
}