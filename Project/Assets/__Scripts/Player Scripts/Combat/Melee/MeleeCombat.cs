using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    private float _timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;
    private Animator _anim;
    private int times = 0;

    private int enemyKilled = EnemySpider.ememiesKilled;


    void Start()
    {
        _anim = GetComponent<Animator>();    // Passing the animator because we want to get the animator component
    }

    // Update is called once per frame
    void Update()
    {
        setDamage();
        if (_timeBtwAttack <= 0)// makes sure the player can only melee attack when the timeBtwShots is over
        {
            if(Input.GetKey(KeyCode.F))// press F to hit
            {
                _anim.SetBool("meleeAttack", true);// plays the melee animation
                _timeBtwAttack = startTimeBtwAttack;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange, whatIsEnemies);// damages all enemies in the circle hit box
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemySpider>().TakeDamage(damage);

                }
            }
        }
        else
        {
            _anim.SetBool("meleeAttack", false);

            _timeBtwAttack -= Time.deltaTime;// decreases the time between attacks
        }
        
    }


    private void setDamage()
    {
        if (EnemySpider.ememiesKilled%3==0 && EnemySpider.ememiesKilled >= 3&&times==0 )
        {
            damage +=0.5f;
            times = 1;
        }
        else if(EnemySpider.ememiesKilled % 3 == 1)
        {
            times = 0;
        }
    //    Debug.Log("MeleeDamage: " + damage);//TEXT
      //  Debug.Log("Enemies: " + EnemySpider.ememiesKilled);//TEXT

    }


    private void OnDrawGizmosSelected()// to visualize the hitBox
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
