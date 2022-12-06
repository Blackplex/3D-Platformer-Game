using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
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
        anim.SetTrigger("Attack");
    }
    void HeavyAttack()
    {
        anim.SetTrigger("Heavy");
    }
}
