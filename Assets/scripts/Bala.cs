using UnityEngine;
using UnityEngine.Events;
public class Bala : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]

    private float damage = 20f;
    [SerializeField]
    private UnityEvent<Transform> onHitEnemy;

    private RigidBody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<RigidBody>();

    }
 private void OnEnable()
       {
          rigidbody.linearVelocity = Transform.forward * speed;
       }
    private void OnTriggerEnter(Collider other)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<enemyHealth>();
            if (enemyHealth != null)

            {
                enemyHealth.TakeDamage(damage);
            }
            SoundManager.instance.Play("hit_object");
            onHitEnemy?.Invoke(Transform);
            gameObject.SetActive(false);
        }
    }
          private void OnDisable()
    {
        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

}
