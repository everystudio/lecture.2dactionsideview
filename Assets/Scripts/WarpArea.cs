using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpArea : MonoBehaviour
{
    [SerializeField] private Transform targetPositionTransform;
    [SerializeField] private Transform popVFXPrefab;

    public Vector3 GetTargetPosition()
    {
        return targetPositionTransform.position;
    }

    public void VanishPlayer(GameObject targetGameObject, float dulation)
    {
        StartCoroutine(SpawnDelay(targetGameObject, dulation));
    }

    IEnumerator SpawnDelay(GameObject targetGameObject, float delayTime)
    {
        targetGameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(delayTime);
        targetGameObject.SetActive(true);
        if (targetGameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = Vector2.up * 2f;
        }
        Instantiate(popVFXPrefab, targetGameObject.transform.position, Quaternion.identity);
    }
}
