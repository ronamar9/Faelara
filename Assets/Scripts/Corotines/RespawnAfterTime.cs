using System.Collections;
using UnityEngine;

public class RespawnAfterTime : MonoBehaviour
{
    private float interval;
    private Coroutine coroutine = null;

    private void Start()
    {
        if (coroutine != null)
        {
            coroutine = StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(interval);
        this.gameObject.SetActive(true);
    }
}
