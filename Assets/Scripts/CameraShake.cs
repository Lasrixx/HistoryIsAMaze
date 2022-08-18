using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 origPos = transform.localPosition;

        float timePassed = 0.0f;
        while (timePassed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, z);

            timePassed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = origPos;
    }
}
