using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    
    [SerializeField] 
    private int healthInitial = 3;
    public int healthCurrent;

    // Is called automatically before the first frame update
    void Start()
    {
        ResetHealth();
    }

    // Sets player's current health back to its initial value
    public void ResetHealth()
    {
        healthCurrent = healthInitial;
    }

    // Reduces player's current health
    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;

        if (healthCurrent <= 0)
        {
            HandleDeath();
        }
    }

    // Handles all the stuff when player looses all hp
    public void HandleDeath()
    {
        // animation
        // u dead interface
        
        // spawn system - reset game
        // game system counts time from start to finish and shows interface
        // - win and loose also counts number of deaths
        
    }

    // Increases player's current health
    public void Heal(int healAmount)
    {
        healthCurrent += healAmount;
        if (healthCurrent > healthInitial)
        {
            ResetHealth();
        }
    }
}