using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Clickable : MonoBehaviour
{
    [SerializeField]
    protected UnityEvent OnClick;

    BoxCollider m_BoxCollider;

    private void Awake()
    {
        m_BoxCollider = GetComponent<BoxCollider>();
        m_BoxCollider.isTrigger = true;
    }

    protected virtual void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
