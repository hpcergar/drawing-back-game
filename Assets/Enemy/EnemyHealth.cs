using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    int difficultyRamp = 4;
    int currentHitPoints = 0;

    Enemy enemy;

    void Start()
    {
        ResetHealth();
        enemy = GetComponent<Enemy>();
    }

    private void ResetHealth()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPoints -= 1;
        if(currentHitPoints <= 0)
        {
            Die();
        }
    }

    private void Die() 
    {
        gameObject.SetActive(false);
        maxHitPoints += difficultyRamp;
        enemy.RewardGold();
    }

    private void OnEnable()
    {
        ResetHealth();
    }
}
