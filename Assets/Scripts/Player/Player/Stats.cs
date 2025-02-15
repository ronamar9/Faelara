using UnityEngine;
public class Stats
{
    public string statName;
    private float maxAmount;
    private float currentAmount;
    public Stats(string statName, float maxAmount)
    {
        this.statName = statName;
        this.maxAmount = maxAmount;
    }

    public float CurrentAmount
    {
        get { return currentAmount; }
        set
        {
            currentAmount = Mathf.Clamp(value, 0, maxAmount);
        }
    }

    public float MaxAmount
    {
        get { return maxAmount; }
    }

    public void Modify(float amount)
    {
        CurrentAmount += amount;
    }

    public void Upgrade(float extraMaxAmount)
    {
        maxAmount += extraMaxAmount;
        currentAmount = maxAmount;
    }
}
