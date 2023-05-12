using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float xRotation, yRotation, smooth;
    [SerializeField] private Transform playerBody;
    public float sensitivity, currentSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            IncreaseSensitivity();
        }
        if(Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
        {
            DecreaseSensitivity();
//            currentSensitivity = 0;
        }

        float mouseX = Input.GetAxis("Mouse X") * currentSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * currentSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void IncreaseSensitivity()
    {
        //currentSensitivity = mouseSensitivity;
        //DOTween.To(() => currentSensitivity, x => currentSensitivity = x, mouseSensitivity, 5f);

        currentSensitivity += smooth * Time.deltaTime;
        currentSensitivity = Mathf.Clamp(currentSensitivity, 0, sensitivity);
    }
    private void DecreaseSensitivity()
    {
        //currentSensitivity = sensitivity;
        //DOTween.To(() => currentSensitivity, x => currentSensitivity = x, 0f, 5f);

        currentSensitivity -= smooth * Time.deltaTime;
        currentSensitivity = Mathf.Clamp(currentSensitivity, 0, sensitivity);
    }
}
