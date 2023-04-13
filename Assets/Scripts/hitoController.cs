using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hitoController : MonoBehaviour
{
    Rigidbody2D rigid2D;

    gameDirectorScript gds;    //게임 디렉터

    //점프변수
    private bool isJumped = false;     //점프중인지 확인 
    private float jumpTime;            //점프력 충전 계수
    public float jumpTimeLimit;        //최대 점프력 
    public float jumpForce;            //점프 기본 계수
    Image jumpGauge;                   //점프게이지

    //방향변수
    public float xMoveForce;     //방향 기본계수
    public float maxMoveForce;   //최대 이동속도

    private AudioSource jumpSound; //점프소리

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        jumpGauge = GameObject.Find("hito/Canvas/jumpGauge").GetComponent<Image>();
        jumpSound = GetComponent<AudioSource>();

        gds = GameObject.Find("GameDirector").GetComponent<gameDirectorScript>();
    }

    void Update()
    {
        //////////////////////////점프/////////////////////////////////
        //점프누르는 동안 점프력 충전
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && isJumped == false)
        {
            if (jumpTime < jumpTimeLimit) {
                jumpTime += Time.deltaTime;
            }

            //점프게이지 채우기
            jumpGauge.fillAmount = jumpTime / jumpTimeLimit;
        }

        //점프력 및 게이지 초기화
        if (isJumped && jumpTime > 0)
        {
            jumpTime = 0;
            jumpGauge.fillAmount = jumpTime;
        }
     
        //점프버튼 떼는 순간 점프 실행
        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space)) && isJumped == false)
        {
            //최소 점프높이 지정
            if (jumpTime < 0.1f)
            {
                this.rigid2D.AddForce(transform.up * jumpForce * 0.1f);
            }
            else
            {
                this.rigid2D.AddForce(transform.up * jumpForce * jumpTime);
            }
            jumpSound.Play();
            isJumped = true;
        }


        //////////////////////////방향전환/////////////////////////////////
        
        Vector3 hitoVelocity = rigid2D.velocity;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Mathf.Abs(hitoVelocity.x) < maxMoveForce)
            {
                this.rigid2D.AddForce(transform.right * xMoveForce, ForceMode2D.Force);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Mathf.Abs(hitoVelocity.x) < maxMoveForce)
            {
                this.rigid2D.AddForce(transform.right * xMoveForce * -1, ForceMode2D.Force);
            }
        }


        // 방향전환 조작감을 위해 점프중 반대쪽 키를 누르면 x축 가속도 초기화
        if (isJumped == true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            rigid2D.velocity = new Vector2(0f, hitoVelocity.y);
        }

        // 방향전환 조작감을 위해 점프상태가 아닐때 반대쪽 키를 떼면 x축 가속도 초기화
        if (isJumped == false && (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            rigid2D.velocity = new Vector2(0f, hitoVelocity.y);
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 hitoVelocity = rigid2D.velocity;
        GameObject obj = col.gameObject;

        if (col.transform.tag == "Ground")
        {
            this.isJumped = false;
        }

        if (col.transform.tag == "Wall")
        {
            GameObject wall = col.gameObject;

            if (wall.name == "rightWall")
            {
                this.rigid2D.AddForce(transform.up * 150f);
                this.rigid2D.AddForce(transform.right * -150f);
            }
            else if(wall.name == "leftWall")
            {
                this.rigid2D.AddForce(transform.up * 150f);
                this.rigid2D.AddForce(transform.right * 150f);
            }
            else if(wall.name == "topWall")
            {
                this.rigid2D.AddForce(transform.up * -150f);
            }
        }

        if(obj.name == "todang")
        {
            gds.SetVictory(true);
            gds.SetEndingTime();
        }
    }
}
