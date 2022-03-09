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
    private float m_Distance = 1920 / 15;
    [SerializeField]
    private float m_ItemWidth = 150;
    // Start is called before the first frame update
    private void Start()
    {
        Gamemanager.GM.OnItemUpdate += ShowInventory;
        m_Distance = m_ItemWidth + 10;
    }

    private void Update()
    {
        ShowTimeInFormat(Gamemanager.GM.GetTime());
        m_Cheese.text = "x" + Gamemanager.GM.m_CheeseCollected.ToString();
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
            rt.sizeDelta = new Vector2(m_ItemWidth, rt.sizeDelta.y);
            item.transform.parent = m_InventoryOrigin;
            print(rt.localScale);
            Image image = item.AddComponent<Image>();
            image.preserveAspect = true;
            item.transform.localPosition = Vector2.right * i * m_Distance;
            image.sprite = k.Value.m_Image;
            rt.localScale = Vector3.one * 0.5f;
            i++;
        }
    }
    #endregion Inventory System
}