using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaptopInteraction : InteractionInterface
{
    public TMP_Text infoText;
    public GameObject gameStatus;
    public void Start()
    {
        interactDistance = 100f;
    }
    protected override bool IsInteracting()
    {
        return input.interact;
    }
    protected override void DefaultUpdate()
    {
        
    }
    protected override void InteractAction()
    {
        infoText.text = "Interacting with laptop";
        gameStatus.GetComponent<GameStatus>().SaveData("BeforeScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("LaptopScene");
    }
    protected override void EndingInteractAction()
    {
        infoText.text = "Ending Interaction with laptop";
    }
    protected override void OnTriggerEnterAction()
    {
        infoText.text = "Press E to interact with laptop";
    }
    protected override void OnTriggerExitAction()
    {
        
    }
}
