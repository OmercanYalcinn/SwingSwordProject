using UnityEngine;

public class SwingSword : MonoBehaviour
{
    public float swingCooldown = 0.5f;
    private float lastSwingTime;
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastSwingTime + swingCooldown)
        {
            Swing();
        }
    }

    void Swing()
    {
        lastSwingTime = Time.time;
        animator.SetTrigger("Swing");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy: " + other.name);
            //other.GetComponent<EnemyHealth>()?.TakeDamage(1);
        }
    }
}
