using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float STEP = 5.0f;
    //インスペクターで設定する
    public float gravity; //重力　
    public float jumpSpeed;//ジャンプする速度
    public float jumpHeight;//高さ制限
    public GroundCheck ground;  //接地判定

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
     
        //右向きに等速で進む
        this.transform.position += new Vector3(STEP * Time.deltaTime, 0, 0);
        //接地判定を得る
        isGround = ground.IsGround(); 
        float ySpeed = -gravity; 
        float verticalKey = Input.GetAxis("Vertical");

          if (isGround)
          {
              if (verticalKey > 0)
              {
                  ySpeed = jumpSpeed;
                  jumpPos = transform.position.y; //ジャンプした位置を記録する
                  isJump = true;
              }
              else
              {
                  isJump = false;
              }
          }
          else if (isJump)
          {
              //上ボタンを押されている。かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
              if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y)
              {
                  ySpeed = jumpSpeed;
              }
              else
              {
                  isJump = false;
              }
          }

        rb.velocity = new Vector2(1, ySpeed); 
    }
}
