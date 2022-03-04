using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Clickable
{
    private void Start()
    {
        OnClick.AddListener(PickUp);
    }
    public void PickUp()
    {
        Gamemanager.GM.CollectCheese();
        Destroy(gameObject);
    }
}
