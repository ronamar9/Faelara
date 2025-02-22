using UnityEngine;

public class Rock : MonoBehaviour
{
    private int life = 3;
    private int hits = 0;
    [SerializeField] private Sprite[] sprites = new Sprite[4];
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[0];
    }
    public void GetDamage()
    {
        hits++;
        if (hits >= life)
        {
            Crush();
        }
        sr.sprite = sprites[hits];
    }

    private void Crush()
    {
        Destroy(this.gameObject);
    }
}
