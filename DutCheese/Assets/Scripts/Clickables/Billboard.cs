using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private bool m_Leaning = false;
    [SerializeField] private bool m_Flipped = false;
    [SerializeField] private bool m_RunInEditor = false;
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        if (!m_Leaning)
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - (m_Flipped ? 0 : 180), 0);
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
    private void OnDrawGizmos()
    {
        if (m_RunInEditor)
        {
            transform.LookAt(Camera.main.transform);
            if (!m_Leaning)
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - (m_Flipped ? 0 : 180), 0);
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
        }
    }
}