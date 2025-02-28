using UnityEngine;
using Mirror;

public class ThirdPersonCameraController : NetworkBehaviour
{
    public Camera playerCamera;

    public Vector3 offset = new Vector3(0f, 3f, -6f);

    public float smoothSpeed = 0.125f;

    public Vector3 lookAtOffset = new Vector3(0f, 1.5f, 0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!isLocalPlayer)
        {
            playerCamera.enabled = false;
            return;
        }
        else
        {
            // Ensure the local player's camera is tagged as MainCamera.
            if (playerCamera != null)
                playerCamera.tag = "MainCamera";
        }
    }

    void LateUpdate()
    {
        // Only update for the local player's camera.
        if (!isLocalPlayer || playerCamera == null)
            return;

        // Calculate the desired position based on player's transform and offset.
        Vector3 desiredPosition = transform.position + transform.TransformDirection(offset);
        Vector3 smoothedPosition = Vector3.Lerp(playerCamera.transform.position, desiredPosition, smoothSpeed);
        playerCamera.transform.position = smoothedPosition;

        // Make the camera look at the player (with an optional vertical offset).
        Vector3 lookAtTarget = transform.position + lookAtOffset;
        playerCamera.transform.LookAt(lookAtTarget);
    }
}
