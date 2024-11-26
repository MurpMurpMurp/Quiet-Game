using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Character References")]
    [SerializeField] private GameObject m_charaGameObject;
    [SerializeField] private CharacterController m_charaController;

    [Header("Current Camera Forward")]
    [SerializeField] public Camera m_camera;

    [Header("Character Stats")]
    [SerializeField] private float m_charaSpeed;
    [SerializeField] private float m_charaRunningSpeed;
    [SerializeField] private float m_charaRotationSpeed;

    [Header("Character Bools (ah ah, character boules)")]
    [SerializeField] private bool m_isRunning = false;

    [Header("Current Control Scheme")]
    [SerializeField] private bool m_tankControl = false;
    [SerializeField] private bool m_modernControl = false;

    private float m_horizontalInput;
    private float m_verticalInput;

    private void Start()
    {
        if (m_tankControl && m_modernControl)
        {
            Debug.LogError("Both Control Scheme Are Currently Active, Please Only Select One To Be True");
            m_tankControl = false;
            m_modernControl = false;
        }

        if (m_charaController == null)
        {
            m_charaController = GetComponent<CharacterController>();
        }

        if (m_charaGameObject == null)
        {
            m_charaGameObject = GetComponent<GameObject>();
        }
    }

    private void Update()
    {
        GetKeyboardInputs();
    }

    private void LateUpdate()
    {
        if (m_tankControl)
        {
            MoveUsingTankControls();
        }
        else
        {
            MoveUsingModernControls();
        }

        if (!m_tankControl && !m_modernControl)
        {
            Debug.Log("dang, we really messed up. Both m_tankControl and m_modernControl are false so we can't move. womp womp.");
        }
    }

    private void GetKeyboardInputs()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
        m_verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_isRunning = true;
        }
        else
        {
            m_isRunning = false;
        }
    }

    private void MoveUsingTankControls()
    {
        Vector3 movDir;

        transform.Rotate(0f, m_horizontalInput * m_charaRotationSpeed * Time.deltaTime, 0f);

        if (!m_isRunning)
        {
            movDir = transform.forward * m_verticalInput * m_charaSpeed;
        }
        else
        {
            movDir = transform.forward * m_verticalInput * m_charaRunningSpeed;
        }

        m_charaController.Move(movDir * Time.deltaTime - Vector3.up * 0.1f);

    }

    private void MoveUsingModernControls()
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
