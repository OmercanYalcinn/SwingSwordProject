using System.Collections;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float delay = 0.3f;
    private bool attackBlocked;

    void Update()
    {
        // Detect left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;

    }
}
