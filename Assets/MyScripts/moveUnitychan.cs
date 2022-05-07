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
    private Animator anim;
    [SerializeField]
    private float runspeed = 10.0f; //走る最大速度
    [SerializeField]
    private float jumpspeed = 80f; //ジャンプするスピード
    [SerializeField]
    private float gravity;
    private bool jumpflag = false;
    private float jumpPos = 0.0f; //ジャンプした場所を記録
    [SerializeField]
    private float jumpHeight; //ジャンプの高さを調節

    //入力キーの値を保持
    private float ix = 0; //Horizontalキーの入力結果を保持(-1 ～ 1)
    private float iy = 0; //Jumpキーの入力結果を保持(-1 ～ 1)

    //接地判定(プレイヤー側の読み込み)
    public groundcheck ground;
    private bool isGround = false;

    //頭上判定(プレイヤー側の読み込み)
    public groundcheck head;
    private bool isHead = false;



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
        isHead = head.IsGround();

        ix = Input.GetAxis("Horizontal");
        iy = Input.GetAxis("Jump");
        float xspeed = runspeed;
        float yspeed = -gravity; //縦軸の速度も自由に変更

        if (isGround)//接地しているとき
        {
            jumpflag = false;
            if (iy > 0)//Jumpキーが押されたとき
            {
                yspeed = jumpspeed;
                jumpPos = transform.position.y; //ジャンプした位置（y軸）を記録
                jumpflag = true;
            }
            else
            {
                jumpflag = false;
            }
        }
        else if (jumpflag) //接地していないとき（ジャンプしているとき）
        {
            //Jumpキーtrueかつ、頭ぶつけていないかつ、高さ制限以下でジャンプ継続
            if (iy > 0 && jumpHeight > transform.position.y - jumpPos && !isHead)
            {
                yspeed = jumpspeed;
            }
            else
            {
                jumpflag = false;
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
        anim.SetBool("jump",jumpflag);
        anim.SetBool("ground", isGround);
        if (ActSceneMG.startflag) //ゲーム開始中なら
        {
            rb.velocity = new Vector2(xspeed, yspeed); //行動
        }
    }
}
