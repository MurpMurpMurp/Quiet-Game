using UnityEngine;

public class TriggerSwitch : MonoBehaviour
{
    [Header("CharacterManager Script Reference")]
    [SerializeField] CharacterManager m_characterManager;

    [Header("Camera Reference")]
    [SerializeField] Camera m_camera;


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && m_characterManager.m_camera != m_camera)
        {
            m_characterManager.m_camera.enabled = false;
            m_camera.enabled = true;
            m_characterManager.m_camera = m_camera;
        }
    }

}
