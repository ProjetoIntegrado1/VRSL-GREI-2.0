using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        [Header("Sensitivities")]
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;

        [Header("Vertical Clamp")]
        public bool clampVerticalRotation = true;
        public float MinimumX = -90f;
        public float MaximumX = 90f;

        [Header("Smoothing")]
        public bool smooth = false;
        public float smoothTime = 5f;

        [Header("Cursor")]
        public bool lockCursor = true;

        private float _rotationX = 0f;
        private Quaternion _characterTargetRot;
        private Quaternion _cameraTargetRot;
        private bool _cursorIsLocked = true;

        public void Init(Transform character, Transform camera)
        {
            _characterTargetRot = character.localRotation;

            // pega rotação atual da câmera em graus (-180..+180)
            _rotationX = camera.localEulerAngles.x;
            if (_rotationX > 180f) _rotationX -= 360f;

            _cameraTargetRot = Quaternion.Euler(_rotationX, 0f, 0f);

            // já aplica no início
            camera.localRotation = _cameraTargetRot;
            character.localRotation = _characterTargetRot;
        }

        public void LookRotation(Transform character, Transform camera)
        {
            // leitura de mouse
            float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            // rotação horizontal no personagem
            _characterTargetRot *= Quaternion.Euler(0f, yRot, 0f);

            // rotação vertical na câmera
            _rotationX -= xRot;
            if (clampVerticalRotation)
                _rotationX = Mathf.Clamp(_rotationX, MinimumX, MaximumX);
            _cameraTargetRot = Quaternion.Euler(_rotationX, 0f, 0f);

            // aplica suavização ou direto
            if (smooth)
            {
                character.localRotation = Quaternion.Slerp(character.localRotation, _characterTargetRot, smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp(camera.localRotation, _cameraTargetRot, smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = _characterTargetRot;
                camera.localRotation = _cameraTargetRot;
            }

            UpdateCursorLock();
        }

        public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if (!lockCursor)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void UpdateCursorLock()
        {
            if (lockCursor)
                InternalLockUpdate();
        }

        private void InternalLockUpdate()
        {
            if (_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        // chamada externa para alternar lock do cursor (por exemplo, via UI)
        public void ToggleCursorLock()
        {
            _cursorIsLocked = !_cursorIsLocked;
        }
    }
}
