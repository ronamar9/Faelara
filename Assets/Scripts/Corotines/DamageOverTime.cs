using System.Collections;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DamageOverTimeC());
    }

    IEnumerator DamageOverTimeC()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator CallToDamage()
    {
        yield return StartCoroutine(DamageOverTimeC());
    }
}
