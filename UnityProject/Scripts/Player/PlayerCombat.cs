using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int attackDamage = 20;
    public float attackRange = 2f;
    public float attackCooldown = 0.8f;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void Attack()
    {
        Debug.Log("Player attacks!");

        Collider[] hitEnemies = Physics.OverlapSphere(
            transform.position,
            attackRange
        );

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
