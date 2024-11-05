using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    public GameObject playerStanding, playerSitting, intText, standText;
    public bool interactable, sitting;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float moveDuration = 1f;
    private float sittingOffsetY = 0.56f; // Offset for player's Y position when sitting
    public float moveBackDistance = 0.5f;  // Adjust this distance as needed


    void Start()
    {
        intText.SetActive(false);
        interactable = false;
        initialPosition = transform.position;


        targetPosition = initialPosition - transform.forward * moveBackDistance;

        // Move the chair to the target position
        // transform.position = targetPosition;
        playerSitting.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(MoveChair());

            }
        }
        if (sitting == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerSitting.SetActive(false);
                standText.SetActive(false);
                playerStanding.SetActive(true);
                sitting = false;
                transform.position = initialPosition;
            }
        }
    }
    IEnumerator MoveChair()
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        PositionPlayerSitting();

        // Ensure the chair reaches the target position
        transform.position = targetPosition;
        intText.SetActive(false);
        standText.SetActive(true);
        playerSitting.SetActive(true);
        sitting = true;
        playerStanding.SetActive(false);
        interactable = false;
    }


    void PositionPlayerSitting()
    {
        Vector3 chairPosition = transform.position;

        // Set playerSitting's position to match chair's X and Z, with Y offset by 0.565
        playerSitting.transform.position = new Vector3(
            chairPosition.x,
            1.326f,
            chairPosition.z
        );
        playerSitting.transform.rotation = transform.rotation;

    }
}