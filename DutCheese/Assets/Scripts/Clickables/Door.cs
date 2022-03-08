using UnityEngine;
using UnityEngine.UI;

public class Door : Clickable
{
    [SerializeField]
    private SpriteRenderer m_DoorSpriteRenderer;
    [SerializeField] private Item m_RequiredItem;
    private InventoryItem m_RequiredInventoryItem;
    [SerializeField]
    private Sprite m_OpenDoor;

    private void Start()
    {
        OnClick.AddListener(OpenDoor);
        m_RequiredInventoryItem = new InventoryItem(m_RequiredItem.GetItem().m_NameKey, m_RequiredItem.GetItem().m_Image);
    }

    public void OpenDoor()
    {
        if (Gamemanager.GM.HasItem(m_RequiredInventoryItem.m_NameKey))
        {
            m_DoorSpriteRenderer.sprite = m_OpenDoor;
            Gamemanager.GM.WinGame();
        }
    }
}