using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class InventoryItem
{
    public string m_NameKey;
    public Sprite m_Image;
    public InventoryItem(string _nameKey, Sprite _image)
    {
        m_NameKey = _nameKey;
        m_Image = _image;
    }
}