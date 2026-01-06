using UnityEngine;

public class FridgeInteraction : InteractionInterface
{
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
        Debug.Log("Interacting with fridge");
    }
    protected override void EndingInteractAction()
    {
        Debug.Log("Ending Interaction with fridge");
    }
    protected override void OnTriggerEnterAction()
    {
        Debug.Log("Press E to interact with fridge");
    }
    protected override void OnTriggerExitAction()
    {
        
    }
}
