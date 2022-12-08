using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public combatAttributes me;
    public combatAttributes opponent;

    public Animator anim;

    public BoxCollider attackBox;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            HeavyAttack();
        }
    }

    void Attack()
    {
        me.damage = 20;
        //play attack animation
        anim.SetTrigger("Attack");
    }
    void HeavyAttack()
    {
        me.damage = 30;
        anim.SetTrigger("Heavy");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            opponent = other.GetComponent<combatAttributes>();
            me.DoDamage(opponent.gameObject);
            Debug.Log("Trigger Enter");
        }
    }
}
