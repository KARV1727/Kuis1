﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{
    public int playerSpeed =10;
    public bool facingRight = true;
    public int playerJumpPower =1250;
    public float moveX;
    
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove(){
        // CONTRILS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump")){
            Jump();
        }
        // ANIMATIONS
        // PLAYER DIRECTIONS
        if (moveX < 0.0f && facingRight==false){
            FlipPlayer();
        } else if(moveX > 0.0f && facingRight == true){
            FlipPlayer();
        }
        // PHYCYS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump(){
        // JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer(){
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
