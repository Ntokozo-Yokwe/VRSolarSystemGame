using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField, Tooltip("Time taken to perform the translation")]
    private float translationTime;

    [SerializeField, Tooltip("Should the user wish for the movement to be offset")]
    private Vector3 offset;

    /// <summary>
    /// Events triggered based on the state of the movement action
    /// </summary>
    public UnityEvent moveInitiated, moveCompleted;

    /// <summary>
    /// Performs a movement over time 
    /// </summary>
    /// <param name="targetPosition"></param>
    /// <returns></returns>
    public IEnumerator MoveOverTime(Vector3 targetPosition)
    {
        float elapsedTime = 0; 
        float percentage = 0;

        // Stores the start and end position
        Vector3 initalPosition = transform.position;
        Vector3 endPosition = targetPosition + offset;

        // Notifies the movement has been initialised
        moveInitiated.Invoke();
        
        while (elapsedTime < translationTime)
        {
            // Forces a delay in the loop execution
            yield return new WaitForEndOfFrame();

            // Update the elapsed time and completion percentage
            elapsedTime += Time.deltaTime;
            percentage = elapsedTime / translationTime;

            // Lerp is transform.position = initialPosition + (endPosition - initialPosition)*percentage; 
            transform.position = Vector3.Lerp(initalPosition, endPosition, percentage);
        }

        // Notifies the movement has been completed
        moveCompleted.Invoke();
    }

    public void StartMovement(Vector3 position)
    {
        StopAllCoroutines();
        StartCoroutine(MoveOverTime(position));
    }

    public void StartMovememt(Transform target)
    {
        StopAllCoroutines();
        StartCoroutine(MoveOverTime(target.position));
    }
}
