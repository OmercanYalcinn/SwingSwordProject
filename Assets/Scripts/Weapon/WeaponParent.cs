using System.Collections;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float delay = 0.3f;
    private bool attackBlocked;

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
