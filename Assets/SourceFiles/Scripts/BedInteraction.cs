using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.TextCore.Text;
using TMPro;
using UnityEngine.UI;

public class BedInteraction : InteractionInterface
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;          // Assign your player here
    public Transform sitPoint;        // Where the player should go
    public Transform standPoint;
    public ThirdPersonController controller;
    public CharacterController characterController;
    public Material nightSky;
    public Material daySky;
    public TMP_Text infoText;

    
    protected override bool IsInteracting()
    {
        return input.interact && !controller.IsLyingDown;
    }
    protected override void DefaultUpdate()
    {
        if (!controller.IsLyingDown) return;
        bool isMoving = input.move.x != 0.0f || input.move.y != 0.0f;
        if (isNear && (isMoving || input.interact))
        {
            if (controller.IsLyingDown) EndingInteractAction();
            input.interact = false;
        }
    }


    protected override void InteractAction()
    {
        // Move player to sit position
        controller.IsLyingDown = true;
        characterController.height = 0.3f;
        characterController.radius = 0.2f;
        player.position = sitPoint.position;
        player.rotation = sitPoint.rotation;
        RenderSettings.skybox = nightSky;
        // DynamicGI.UpdateEnvironment();
        // Debug.Log("Player is now on the bed!");
        infoText.text = "Good night. Press E to wake up";
        TasksSystem.Instance.UpdateTasks("bed_down");
        GameStatus.Instance.SleepForHours(7);
    }

    protected override void EndingInteractAction()
    {
        controller.IsLyingDown = false;
        characterController.height = 1.8f;
        characterController.radius = 0.28f;
        player.rotation = standPoint.rotation;
        player.position = standPoint.position;
        RenderSettings.skybox = daySky;
        // DynamicGI.UpdateEnvironment();
        infoText.text = "Good morning";
        TasksSystem.Instance.UpdateTasks("bed_up");
    }

    protected override void OnTriggerEnterAction()
    {
        player.GetComponent<CapsuleCollider>().enabled = false;
        // Debug.Log("Press E to interact with bed");
        infoText.text = "Press E to go to sleep";
    }

    protected override void OnTriggerExitAction()
    {
        player.GetComponent<CapsuleCollider>().enabled = true;
            if (controller.IsLyingDown) EndingInteractAction();
    }
}
