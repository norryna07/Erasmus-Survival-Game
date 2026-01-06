using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.TextCore.Text;

public class BedInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;          // Assign your player here
    public Transform sitPoint;        // Where the player should go
    public Transform standPoint;
    public float interactDistance = 2f;
    public Camera playerCamera;
    public StarterAssetsInputs input;
    public ThirdPersonController controller;
    public CharacterController characterController;

    private bool isNear = false;

    private bool interactPressed = false;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (isNear && input.interact && !controller.IsLyingDown)
                {
                    SitOnBed();
                    input.interact = false;
                    return;
                }
            }
        }
        if (isNear && input.interact && !controller.IsLyingDown)
        {
            input.interact = false;
        }
        if (!controller.IsLyingDown) return;
        bool isMoving = input.move.x != 0.0f || input.move.y != 0.0f;
        if (isNear && (isMoving || input.interact))
        {
            if (controller.IsLyingDown) StandUp();
            input.interact = false;
        }

    }


    void SitOnBed()
    {
        // Move player to sit position
        controller.IsLyingDown = true;
        characterController.height = 0.3f;
        characterController.radius = 0.2f;
        Debug.Log("x" + sitPoint.position.x);
        Debug.Log("y" + sitPoint.position.y);
        Debug.Log(sitPoint.rotation);
        player.position = sitPoint.position;
        player.rotation = sitPoint.rotation;
        Debug.Log("x" + player.position.x);
        Debug.Log("y" + player.position.y);
        Debug.Log(player.rotation);
        Debug.Log("Player is now on the bed!");
    }

    void StandUp()
    {
        controller.IsLyingDown = false;
        characterController.height = 1.8f;
        characterController.radius = 0.28f;
        player.rotation = standPoint.rotation;
        player.position = standPoint.position;
    }

    // Detect when player is near
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            player.GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log("Press E to interact with bed");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            player.GetComponent<CapsuleCollider>().enabled = true;
            if (controller.IsLyingDown) StandUp();
        }
    }
}
