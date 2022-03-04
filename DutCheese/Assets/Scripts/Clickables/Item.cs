using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Clickable
{
    [SerializeField]
    private InventoryItem m_MyItem = new InventoryItem("", null);
    private void Start()
    {
        if (GetComponent<SpriteRenderer>() != null)
            m_MyItem.m_Image = GetComponent<SpriteRenderer>().sprite;
    }
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        Gamemanager.GM.CollectItem(new InventoryItem(m_MyItem.m_NameKey, m_MyItem.m_Image));
        print("Found " + m_MyItem.m_NameKey);
        Destroy(gameObject);
    }
}