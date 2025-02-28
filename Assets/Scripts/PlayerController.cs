using UnityEngine;
using Mirror;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 720f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new(h, 0, v);
        if (inputDir.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        moveDirection = inputDir.normalized * moveSpeed;
        controller.SimpleMove(moveDirection);
    }
}
