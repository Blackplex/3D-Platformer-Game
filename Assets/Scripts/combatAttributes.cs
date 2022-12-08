using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatAttributes : MonoBehaviour
{
    public int health;
    public int damage;
    public Animator anim;

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void DoDamage(GameObject target)
    {
        var atm = target.GetComponent<combatAttributes>();
        if(atm != null)
        {
            atm.TakeDamage(damage);
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger("Defeat");
            Destroy(this.gameObject, 2);
        }
    }
}
