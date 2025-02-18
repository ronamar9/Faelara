using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 10f;
    public Image StaminaBar;


    void Update()
    {
        RegenerateStamina();
    }

    /// <summary>
    /// Regenerates the Stamina accoring to the player being an animal or not.
    /// </summary>
    private void RegenerateStamina()
    {

        // Regenerate over time, up to the maximum if not an animal
        if (currentStamina < maxStamina)
        {
            currentStamina += (staminaRegenRate * Time.deltaTime);
            currentStamina = Mathf.Min(currentStamina, maxStamina); // Clamp to maxStamina
        }
    }

}
