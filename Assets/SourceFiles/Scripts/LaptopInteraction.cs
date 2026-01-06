using UnityEngine;

public class LaptopInteraction : InteractionInterface
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
        Debug.Log("Interacting with laptop");
    }
    protected override void EndingInteractAction()
    {
        Debug.Log("Ending Interaction with laptop");
    }
    protected override void OnTriggerEnterAction()
    {
        Debug.Log("Press E to interact with laptop");
    }
    protected override void OnTriggerExitAction()
    {
        
    }
}
