using System.Collections;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour
{
    /// <summary>
    /// Makes the Crumpling Platfrom start to lose opacity and then disapear. Respawns the platfrom after a certain time.
    /// </summary>


    private SpriteRenderer sr;
    private Color Color;
    private BoxCollider2D BoxCollider2D;
    [SerializeField] private float secondsToRespawn;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Color = sr.color;
        BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(StartCrumbling());
    }

    private IEnumerator StartCrumbling()
    {
        yield return new WaitForSeconds(1f);
        Color.a /= 1.5f;
        sr.color = Color;
        yield return new WaitForSeconds(1f);
        Color.a /= 1.5f;
        sr.color = Color;
        yield return new WaitForSeconds(1f);
        Color.a = 0;
        sr.color = Color;
        BoxCollider2D.enabled = false;
        yield return new WaitForSeconds(secondsToRespawn);
        Color.a = 1;
        sr.color = Color;
        BoxCollider2D.enabled = true;
    }

}
