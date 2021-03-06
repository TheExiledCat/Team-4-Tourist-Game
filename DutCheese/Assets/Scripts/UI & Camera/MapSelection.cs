using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    [SerializeField]
    Transform m_SkyPosition, m_MainCameraPosition, m_CameraPosition;
    [SerializeField]
    CanvasGroup m_Map;
    Transform m_CurrentPosition;
    float m_LerpTime = 5f;
    float m_CurrentLerpTime = 0f;
    string m_SelectedScene;

    public void SetSelectedScene(string selectedScene)
    {
        m_SelectedScene = selectedScene;
    }

    public void GoToSelectedScene()
    {
        //PanToMainCamera();
        SceneManager.LoadScene(m_SelectedScene, LoadSceneMode.Single);
        Gamemanager.GM.InitiateLevel();
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    private void PanToMainCamera()
    {
        Debug.Log("pan");
        m_CurrentPosition = m_CameraPosition.transform;
        if (m_CurrentPosition = m_SkyPosition)
        {
            m_Map.alpha = 0;
                m_MainCameraPosition.localPosition = Vector3.Lerp(m_SkyPosition.position, m_MainCameraPosition.position, m_LerpTime);
                m_MainCameraPosition.localRotation = Quaternion.Lerp(m_SkyPosition.rotation, m_MainCameraPosition.rotation, m_LerpTime);
        }
    }
}
