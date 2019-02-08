using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour {

	public int damage = 10;

	private void OnCollisionEnter (Collision other)
    {
        TakeDamage(other);
    }

	private void OnCollisionStay(Collision other) {
        TakeDamage(other);		
	}

    private void TakeDamage(Collision other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Hit(damage, transform.position);
        }
    }
}