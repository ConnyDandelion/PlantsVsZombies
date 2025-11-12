using UnityEngine;
using System.Collections;
public class BasePlant : MonoBehaviour
{
    [Header("Common Components")]
    [SerializeField]
    public Health health;
    public Health Health => health;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public Collider collider;
    public Step currentStep;
    public Step CurrentStep
    {
        set { currentStep = value; }
    }
    protected bool isActive;
    public virtual bool IsActive
    {
        set
        {
            isActive = value;
            collider.enabled = value;
        }
    }
    
    protected IEnumerator DieRoutine(string dieAnimationName)
    {
        isActive = false;
        animator.Play(dieAnimationName, 0, 0f);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
}
