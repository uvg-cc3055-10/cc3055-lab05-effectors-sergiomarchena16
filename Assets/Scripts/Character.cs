﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {


    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;
    private float speed = 5f;
    private float jumpForce = 250f;
    private bool facingRight = true;
 
	public GameObject feet;
	public LayerMask layerMask;


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
	

	void Update () {
        float move = Input.GetAxis("Horizontal");
        if (move != 0) {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            facingRight = move > 0;
        }

        anim.SetFloat("Speed", Mathf.Abs(move));

        sr.flipX = !facingRight;

		if (Input.GetButtonDown("Jump")) { 
			RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.5f, layerMask);
			if (raycast.collider != null) 
				rb2d.AddForce(Vector2.up*jumpForce);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("flag1"))
			SceneManager.LoadScene("Dungeon2");
		if(collision.CompareTag("flag2"))
			SceneManager.LoadScene("Dungeon3");
		if(collision.CompareTag("flag3"))
			SceneManager.LoadScene("Dungeon1");
	}
}
