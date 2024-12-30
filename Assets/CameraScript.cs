using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform secondTransformPosition; // Target position for the initial transition
    public float camMoveSpeed = 5f; // Speed of camera movement

    public int[] currentGridPosition = new int[2] { 0, 0 };
    private bool isGameStart = false; 
    private bool isTransitionToNextLetter = false;

    private bool isZoomIn = false;

    private bool isPanOut = false;
    private Vector3 nextLetterPosition;
    private Vector3 zoomInPosition;

    private Vector3 panOutPosition = new Vector3(44.9000015f, -50.5f, 95f);

    public float duration = 1f;



    public float gridToCameraDistance = 1f;
    public float gridXSize = 1f;

    private void Update()
    {
        // Handle the game start transition
        if (isGameStart)
        {
            MoveCameraToTarget(secondTransformPosition.position, secondTransformPosition.rotation, () =>
            {
                isGameStart = false; // Stop transition after reaching the target
            });
        }

        // Handle transition to the next letter
        if (isTransitionToNextLetter)
        {
            MoveCameraToTarget(nextLetterPosition, transform.rotation, () =>
            {
                isTransitionToNextLetter = false; // Stop transition after reaching the next letter
                Debug.Log("Transitioned to the next letter");

            });
        }

        // Handle zooming in to the letter
        if (isZoomIn)
        {
            MoveCameraToTarget(zoomInPosition, transform.rotation, () =>
            {
                isZoomIn = false; // Stop transition after reaching the target
                Debug.Log("Zoomed in to the letter");

            });
        }

        if(isPanOut)
        {
            MoveCameraToTarget(panOutPosition, transform.rotation, () =>
            {
                isPanOut = false; // Stop transition after reaching the target
                Debug.Log("Panned out to the original position");

            });
        }
    }

    private void MoveCameraToTarget(Vector3 targetPosition, Quaternion targetRotation, System.Action onComplete)
    {
        // Smoothly transition the camera's position and rotation
        transform.position = Vector3.Lerp(transform.position, targetPosition, camMoveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, camMoveSpeed * Time.deltaTime);

        // Check if the camera has reached the target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            transform.position = targetPosition;
            transform.rotation = targetRotation;
            onComplete?.Invoke(); // Trigger the onComplete callback
        }
    }

    public void NextLetterTransition()
    {
        Debug.Log("Transitioning to the next letter");
        nextLetterPosition = new Vector3(transform.position.x + gridXSize, transform.position.y, transform.position.z );
        isTransitionToNextLetter = true;
    }

    public void GameStartTransition()
    {
        Debug.Log("Starting game transition");
        isGameStart = true;
    }

    public void ZoomInToLetter( Word word )
    {
        Debug.Log("Zooming in to the letter");

        Letter firstLetter = word.getLetters()[0];

        Vector3 firstLetterCoordinates = firstLetter.getCoordinates();

        currentGridPosition[0] = firstLetter.getRowNumber();
        currentGridPosition[1] = firstLetter.getColNumber();

        Debug.Log("Current Camera Grid Position [" + currentGridPosition[0] + " " + currentGridPosition[1] + "]");

        zoomInPosition = new Vector3(firstLetterCoordinates.x, firstLetterCoordinates.y, 192.5f);

        //zoomInPosition = new Vector3(transform.position.x + gridToCameraDistance, firstLetterCoordinates[1], firstLetterCoordinates[0]);
        isZoomIn = true;
    }

    public void PanOutToOriginalPosition()
    {
        Debug.Log("Panning out to the original position");
        isPanOut = true;
    }

    public void ShakeCamera(){
        StartCoroutine(Shaking());
    }
    IEnumerator Shaking(){
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }

        transform.position = startPosition;
    }
}


