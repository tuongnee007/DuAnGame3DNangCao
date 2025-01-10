using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAB3_3 : MonoBehaviour
{
    public Transform[] objectsToMove;
    public Vector3 targetPosition = Vector3.zero;
    public float duration = 5f;
    private void Start()
    {
        StartCoroutine(MoveObjectsSequentially());
    }
    private IEnumerator MoveObjectsSequentially()
    {
        foreach(Transform obj in objectsToMove)
        {
            yield return StartCoroutine(MoveObject(obj,targetPosition,duration));
            yield return new WaitForSeconds(1f);
        }
    }
    private IEnumerator MoveObject(Transform obj, Vector3 tagert, float duration)
    {
        Vector3 startPosition = obj.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            obj.position = Vector3.Lerp(startPosition, tagert, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.position = tagert;
    }
}
