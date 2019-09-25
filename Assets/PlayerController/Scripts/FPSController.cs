using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    /* LOOK */
    [HideInInspector] private float yaw; // Rotación Y
    [HideInInspector] private float ptich; // Rotación de la cámara
    [SerializeField] private float yawSpeed = 360.0f;
    [SerializeField] private float pitchSpeed = 180.0f;
    [SerializeField] private float minPitch = -80.0f;
    [SerializeField] private float maxPitch = 50.0f;
    [SerializeField] private Transform pitchControllerTransform;

    /* MOVEMENT */
    [HideInInspector] private CharacterController characterController;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode rightKeyCode = KeyCode.D;
    [SerializeField] private KeyCode upKeyCode = KeyCode.W;
    [SerializeField] private KeyCode downKeyCode = KeyCode.S;

    /* GRAVITY */
    [HideInInspector] private float verticalSpeed = 0.0f;
    [HideInInspector] private bool onGround = false;
    [SerializeField] private Vector3 gravity;

    /* JUMP */
    public KeyCode m_RunKeyCode = KeyCode.LeftShift;
    public KeyCode m_JumpKeyCode = KeyCode.Space;
    public float m_FastSpeedMultiplier = 1.2f;
    public float m_JumpSpeed = 10.0f;


    void Awake()
    {
        yaw = transform.rotation.eulerAngles.y;
        ptich = pitchControllerTransform.localRotation.eulerAngles.x;
        characterController = GetComponent<CharacterController>();


        Cursor.lockState = CursorLockMode.Locked;


    }

    void Update()
    {

        /* LOOK */
        float axisY = -Input.GetAxis("Mouse Y");
        ptich += axisY * pitchSpeed * Time.deltaTime;
        ptich = Mathf.Clamp(ptich, minPitch, maxPitch);
        pitchControllerTransform.localRotation = Quaternion.Euler(ptich, 0.0f, 0.0f);

        float axisX = Input.GetAxis("Mouse X");
        yaw += axisX * yawSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, yaw, 0);


        /* MOVEMENT */

        Vector3 movement = Vector3.zero;

        float yawInRadius = yaw * Mathf.Deg2Rad;
        float yaw90InRadius = (yaw + 90.0f) * Mathf.Deg2Rad;
        Vector3 forward = new Vector3(Mathf.Sin(yawInRadius), 0.0f, Mathf.Cos(yawInRadius));
        Vector3 right = new Vector3(Mathf.Sin(yaw90InRadius), 0.0f, Mathf.Cos(yaw90InRadius));

        if (Input.GetKey(upKeyCode))
            movement = forward;
        else if (Input.GetKey(downKeyCode))
            movement = -forward;

        if (Input.GetKey(rightKeyCode))
            movement += right;
        else if (Input.GetKey(leftKeyCode))
            movement -= right;

        movement.Normalize();

        float speedMultiplier = 1;
        if (Input.GetKey(m_RunKeyCode))
            speedMultiplier = m_FastSpeedMultiplier;

        movement *= Time.deltaTime * speed * speedMultiplier;


        /* GRAVITY */

        verticalSpeed += gravity.y * Time.deltaTime;
        movement.y = verticalSpeed * Time.deltaTime;

        CollisionFlags collisionFlags = characterController.Move(movement);

        if ((collisionFlags & CollisionFlags.Below) != 0)
        {
            onGround = true;
            verticalSpeed = 0.0f;
        }
        else
            onGround = false;

        if ((collisionFlags & CollisionFlags.Above) != 0 && verticalSpeed > 0.0f)
            verticalSpeed = 0.0f;


        /* SALTO */

        if (onGround && Input.GetKeyDown(m_JumpKeyCode))
            verticalSpeed = m_JumpSpeed;


    }


}
