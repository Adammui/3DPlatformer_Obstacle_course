using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    
    [SerializeField] 
    private int healthInitial = 3;
    private int healthCurrent;

    // Is called automatically before the first frame update
    void Start()
    {
        // Initialiase the player's current health
        ResetHealth();
    }

    // Sets the player's current health back to its initial value
    public void ResetHealth()
    {
        // Reset the player's current health
        healthCurrent = healthInitial;
    }

    // Reduces the player's current health
    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        if (healthCurrent <= 0)
        {
            // Kill the player
            Destroy(gameObject);

            // NB: Here, you may want to restart the game
            // (e.g. by informing your game manager that the player has died,
            // or by raising an event using your event system)
        }
    }

    // Increase the player's current health
    public void Heal(int healAmount)
    {
        healthCurrent += healAmount;
        if (healthCurrent > healthInitial)
        {
            ResetHealth();
        }
    }
}