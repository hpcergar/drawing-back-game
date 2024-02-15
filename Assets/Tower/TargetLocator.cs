using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closest = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closest = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closest;
    }

    void AimWeapon()
    {
        if(target == null)
        {
            return;
        }
        float targetDistance = Vector3.Distance(transform.position, target.position);
        Attack(targetDistance < range);
        weapon.LookAt(target);
    }

    void Attack(bool isActive)
    {
        if (isActive && projectileParticles.isStopped)
        {
            projectileParticles.Play();
        }   else if(!isActive && projectileParticles.isPlaying)
        {
            projectileParticles.Stop();
        }
    }
}
