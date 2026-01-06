using UnityEngine;
using StarterAssets;

public abstract class InteractionInterface : MonoBehaviour
{
    public float interactDistance = 2f;
    public Camera playerCamera;
    public StarterAssetsInputs input;
    protected bool isNear = false;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (isNear && IsInteracting())
                {
                    InteractAction();
                    input.interact = false;
                    return;
                }
            }
        }
        if (isNear && IsInteracting())
        {
            input.interact = false;
        }
        DefaultUpdate();

    }

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            OnTriggerEnterAction();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            OnTriggerExitAction();
        }
    }

    protected abstract bool IsInteracting() ;
    protected abstract void DefaultUpdate();
    protected abstract void InteractAction();
    protected abstract void EndingInteractAction();
    protected abstract void OnTriggerEnterAction();
    protected abstract void OnTriggerExitAction();


}
