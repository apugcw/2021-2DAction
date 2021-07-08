using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
#region//インスペクターで設定する
     [Header("移動速度")]public float speed;
     [Header("重力")]public float gravity;
     [Header("画面外でも行動する")] public bool nonVisibleAct;
     #endregion
 
     #region//プライベート変数
     private Rigidbody2D rb = null;
     private SpriteRenderer sr = null;
     private bool rightTleftF = false;
     #endregion
 
     // Start is called before the first frame update
     void Start()
     {
         rb = GetComponent<Rigidbody2D>();
         sr = GetComponent<SpriteRenderer>();
     }
 
     void FixedUpdate()
     {
         if (sr.isVisible || nonVisibleAct)
         {
             int xVector = -1;
             if (rightTleftF)
             {
                 xVector = 1;
                 transform.localScale = new Vector3(-1, 1, 1);
             }
             else
             {
                 transform.localScale = new Vector3(1, 1, 1);
             }
             rb.velocity = new Vector2(xVector * speed, -gravity);
         }
　　　　 else
         {
             rb.Sleep();
         }
     }
 }