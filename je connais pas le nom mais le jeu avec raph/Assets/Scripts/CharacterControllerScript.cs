using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Character Game Object Reference")]
    [SerializeField] private GameObject m_characterGO;

    [Header("Current Camera Forward")]
    [SerializeField] public Camera m_camera;

    [Header("Character Stats")]
    [SerializeField] private float m_charaSpeed;
    [SerializeField] private float m_charaRunningSpeed;
    [SerializeField] private float m_charaRotationSpeed;

    private void Update()
    {

    }

    private void CheckKeyboardInput()
    {

    }

    /*
     private void UnleashMurderClowns()
    {
     ------ Content Redacted For Public Safety Reasons ------
                                             - The government
    }
    */
}
