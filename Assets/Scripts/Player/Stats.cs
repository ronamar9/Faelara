using UnityEngine;
public class Stats
{
    public string statName;
    public float maxAmount { get; private set; }
    public float currentAmount { get; private set; }
    private float regenarationRate = 1f;

    public Stats(string statName, float maxAmount, float currentAmount)
    {
        this.statName = statName;
        this.maxAmount = maxAmount;
        this.currentAmount = currentAmount;
    }

    public void Modify(float amount)
    {
        currentAmount += amount;
    }

    public void Upgrade(float extraMaxAmount)
    {
        maxAmount += extraMaxAmount;
        currentAmount = maxAmount;
    }

    public void RegenerateStat()
    {
        currentAmount += (regenarationRate * Time.deltaTime);
        currentAmount = Mathf.Min(currentAmount, maxAmount);
    }
}
