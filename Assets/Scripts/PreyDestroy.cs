using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyDestroy : MonoBehaviour
{
    public void DestroyObjectDelayed()
    {
        StartCoroutine(DestroyAfterDelay(1.9f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
