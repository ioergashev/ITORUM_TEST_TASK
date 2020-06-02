using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itorum
{
    public class CameraRotateSystem : MonoBehaviour
    {
        private CameraRotateComponent rotateComponent;
        private Camera camera;

        private Quaternion camRot = Quaternion.identity;
        private Quaternion camRootRot = Quaternion.identity;

        private void Awake()
        {
            rotateComponent = GetComponent<CameraRotateComponent>();
            camera = GetComponent<Camera>();

            camRot = camera.transform.localRotation;
            camRootRot = camera.transform.parent.localRotation;
        }

        private void Update()
        {
            // Если зажата правая кнопка мыши
            if (Input.GetMouseButton(1))
            {
                float hor = Input.GetAxis("Mouse X");
                float vert = Input.GetAxis("Mouse Y");

                // Вращение по вертикали
                camRot.x += vert * rotateComponent.ScrollSpeed * Time.deltaTime * (rotateComponent.InvertVert? 1: -1);
                camRot.x = Mathf.Clamp(camRot.x, rotateComponent.MinXRotLimit, rotateComponent.MaxXRotLimit);

                // Вращение по горизонтали
                camRootRot.y += hor * rotateComponent.ScrollSpeed * Time.deltaTime * (rotateComponent.InvertHor ? -1 : 1);

                camera.transform.localRotation = Quaternion.Euler(camRot.x, camRot.y, camRot.z);
                camera.transform.parent.localRotation = Quaternion.Euler(camRootRot.x, camRootRot.y, camRootRot.z);
            }
        }
    }
}