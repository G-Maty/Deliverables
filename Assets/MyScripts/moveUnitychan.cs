using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*　移動の実装方針
 * ・横の移動は物理法則無視（velocity.xの値のみをいじる）
 * ・ジャンプは物理法則に基づく（接地判定がtrueのときのみ上方向に力を加える）
 */
public class moveUnitychan : MonoBehaviour
{
    private Rigidbody2D rb;
    private float ix = 0; //Horizontalキーの入力結果を保持(-1 ～ 1)
    private float iy = 0; //Jumpキーの入力結果を保持(-1 ～ 1)
    private Animator anim;
    [SerializeField]
    private float runspeed = 10.0f; //走る最大速度
    [SerializeField]
    private float jumpforce = 700f; //飛ぶために加える力
    private bool jumpflag = false;

    //接地判定(プレイヤー側の読み込み)
    public groundcheck ground;
    private bool isGround = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //物理エンジンの計算前にこの処理を行う
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();

        ix = Input.GetAxis("Horizontal");
        iy = Input.GetAxis("Jump");
        float xspeed = runspeed;

        if (isGround)//接地しているとき
        {
            jumpflag = false;
            anim.SetBool("jump", false);
            if (iy > 0)//Jumpキーが押されたとき
            {
                anim.SetBool("jump",true);
                rb.AddForce(transform.up * jumpforce); //transform.upは長さ１の上方向ベクトル（transform.up = (0,1,0) ）
                jumpflag = true;
            }
        }

        if (ix != 0) //移動中
        {
            anim.SetBool("run", true);
            if (jumpflag)
            {
                anim.SetBool("jump",true);
            }
            else
            {
                anim.SetBool("jump", false);
            }

            if (ix < 0) //左
            {
                transform.localScale = new Vector3(-5, 5, 1);
                xspeed = runspeed * ix;
            }
            else //右
            {
                transform.localScale = new Vector3(5, 5, 1);
                xspeed = runspeed * ix;
            }
        }
        else //停止中
        {
            anim.SetBool("run", false);
            xspeed = 0.0f;
        }
        rb.velocity = new Vector2(xspeed, rb.velocity.y); //行動
    }
}
