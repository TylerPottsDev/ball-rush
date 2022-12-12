using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	[SerializeField] private float power;
	[SerializeField] private float attackSpeed;
	[SerializeField] private Rigidbody2D rb;

	[HideInInspector] public bool attacking;
	private Transform _player;
	private float _timeUntilAttack;

	private void Start () {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_timeUntilAttack = attackSpeed;
	}

	private void Update () {
		if (_timeUntilAttack > 0) _timeUntilAttack -= Time.deltaTime;
		else if (!attacking) Attack();

		if (attacking && rb.velocity.magnitude < 10f) attacking = false;
	}

	private void Attack () {
		attacking = true;
		Vector2 direction = (_player.position - transform.position).normalized;
		rb.AddForce(direction * power, ForceMode2D.Impulse);
		_timeUntilAttack = attackSpeed;
	}

}
