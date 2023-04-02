using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    // Variables

    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    public Transform LookTarget;

    float xRotation;
    float yRotation;

    bool lockedCurser = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        transform.LookAt(LookTarget);
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float inputY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += inputX;
        xRotation -= inputY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
