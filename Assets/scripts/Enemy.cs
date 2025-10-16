using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]

    private EnemyData enemyData;

    [SerializeField]

    private Health health;
    [SerializeField]

    private Animator animator;
    [SerializeField]

    private LayerMask enemiesLayer;
    [SerializeField]

    private float raycastOffset = 2f;
    private bool isAttacking = false;

    private Coroutine attackCoroutine;

    private Health targetHealth;

    private void OnEnable()
{
        health.InitializeHealth(enemyData.health);
        StartLooking();
    
    }
    private void StartLooking()
    {
        isAttacking = false;
        animator.Play(enemyData.walkAnimation);

    }

    private void Update()
    {
        if (isAttacking)
        {
            transform.Translate(Vector3.left * enemyData.speed * Time.deltaTime);
            Vector3 forward = transform.TransformDirection(Vector3.left);

            if (Physics.Raycast(transform.position, forward, out RaycastHit hit, enemyData.attackRange, enemiesLayer))
            {
                isAttacking = true;
                targetHealth = hit.collider.GetComponent<Health>();
                attackCoroutine = StartCoroutine(Attack());

            }
        }
    }
    private IEnumerator Attack()
    {
        while (targetHealth.CurrentHealth > 0)
        {
            animator.Play(enemyData.attackAnimation);
            yield return new WaitForSeconds(2f);
            targetHealth.TakeDamage(enemyData.damage);
            yield return new WaitForSeconds(2f);

        }
    }
        public void onDie()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            Destroy(gameObject, 1f);
        }
    }
    

        
    
        
    
}
