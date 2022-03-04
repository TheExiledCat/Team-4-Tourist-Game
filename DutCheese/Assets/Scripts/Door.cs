using UnityEngine;
using UnityEngine.UI;

public class Door : Clickable
{
    [SerializeField]
    SpriteRenderer m_DoorImage;
    [SerializeField]
    Sprite m_OpenDoor;

    private void Start()
    {
        OnClick.AddListener(OpenDoor);
    }

    public void OpenDoor()
    {
        m_DoorImage.sprite = m_OpenDoor;
    }
}
