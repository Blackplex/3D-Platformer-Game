using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public combatAttributes me;
    public combatAttributes opponent;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            opponent = other.GetComponent<combatAttributes>();
            me.DoDamage(opponent.gameObject);
            Debug.Log("Trigger Enter");
        }
    }
}
