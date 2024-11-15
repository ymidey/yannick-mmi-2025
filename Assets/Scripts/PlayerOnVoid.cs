using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (CharacterController))]

public class PlayerOnVoid : MonoBehaviour
{
    // Start is called before the first frame
    [SerializeField] private float m_Threshold;

    Vector3 m_Origin;
    CharacterController m_CharacterController;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        m_Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < m_Threshold)
        {
            Respawn();
        }
    }

    public void OnRespawn(InputValue value)
    {
        Respawn();
    }

    private void Respawn()
    {
        m_CharacterController.enabled = false;
        transform.position = m_Origin;
        m_CharacterController.enabled = true;
    }
}
