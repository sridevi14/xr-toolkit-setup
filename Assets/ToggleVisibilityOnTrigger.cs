using UnityEngine;

public class ToggleVisibilityOnTrigger : MonoBehaviour
{
    // Assign the parent GameObject in the Inspector
    public GameObject parentObject;
    private void Start()
    {
        // Hide all child objects of the parent object at the start
        SetChildrenActive(false);
    }

    // Detect when another object enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is the player
        if (other.CompareTag("Player"))
        {
            // Enable all child objects of the parent object
            SetChildrenActive(true);
        }
    }

    // Detect when the object exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object is the player
        if (other.CompareTag("Player"))
        {
            // Disable all child objects of the parent object
            SetChildrenActive(false);
        }
    }

    // Helper method to toggle active state of all children
    private void SetChildrenActive(bool state)
    {
        foreach (Transform child in parentObject.transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}
