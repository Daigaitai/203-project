using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public Transform target;

    public float speed;
    private Transform player;
    public float lineOfSite;
    public Animator animator;

    public float attackRange;
    float nextAttackTime = 0f;
    public Transform attackPoint;
    public LayerMask playerLayer;

    public int damage;
    private float lastAttackTime;
    public float attackDeley;
    public Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("HeroKnight").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.currentHealth < 0) { return; };

        //Attack
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            animator.SetBool("Run", false);
            //Check to see if enoght time has passed since we last attacked
            if (Time.time > lastAttackTime + attackDeley)
            {

                target.SendMessage("TakeDamage", damage);
                // Record the time we attacked
                lastAttackTime = Time.time;
        
                animator.SetTrigger("isAttacking 0");
    

                nextAttackTime = Time.time + 0f / attackRange;
            }
        }
      
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange)
        {
            //Run animation
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

    }
    void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
  
        //Damage them
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<HeroKnight>().TakeDamage(playerLayer);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
