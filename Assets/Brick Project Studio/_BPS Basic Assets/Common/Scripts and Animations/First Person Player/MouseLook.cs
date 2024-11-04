using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseXSensitivity = 100f;
        public Transform playerBody;

        float xRotation = 0f;
        bool isCursorLocked = true; // Track cursor lock state

        // Start is called before the first frame update
        void Start()
        {
            LockCursor();
        }

        // Update is called once per frame
        void Update()
        {
            // Toggle cursor lock state with the Escape key
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isCursorLocked = !isCursorLocked;

                if (isCursorLocked)
                    LockCursor();
                else
                    UnlockCursor();
            }

            // Only rotate camera when cursor is locked
            if (isCursorLocked)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseX);
            }
        }

        void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
