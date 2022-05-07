using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*�@�ړ��̎������j
 * �E���̈ړ��͕����@�������ivelocity.x�̒l�݂̂�������j
 * �E�W�����v�͕����@���Ɋ�Â��i�ڒn���肪true�̂Ƃ��̂ݏ�����ɗ͂�������j
 */
public class moveUnitychan : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]
    private float runspeed = 10.0f; //����ő呬�x
    [SerializeField]
    private float jumpspeed = 80f; //�W�����v����X�s�[�h
    [SerializeField]
    private float gravity;
    private bool jumpflag = false;
    private float jumpPos = 0.0f; //�W�����v�����ꏊ���L�^
    [SerializeField]
    private float jumpHeight; //�W�����v�̍����𒲐�

    //���̓L�[�̒l��ێ�
    private float ix = 0; //Horizontal�L�[�̓��͌��ʂ�ێ�(-1 �` 1)
    private float iy = 0; //Jump�L�[�̓��͌��ʂ�ێ�(-1 �` 1)

    //�ڒn����(�v���C���[���̓ǂݍ���)
    public groundcheck ground;
    private bool isGround = false;

    //���㔻��(�v���C���[���̓ǂݍ���)
    public groundcheck head;
    private bool isHead = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //�����G���W���̌v�Z�O�ɂ��̏������s��
    void FixedUpdate()
    {
        //�ڒn����𓾂�
        isGround = ground.IsGround();
        isHead = head.IsGround();

        ix = Input.GetAxis("Horizontal");
        iy = Input.GetAxis("Jump");
        float xspeed = runspeed;
        float yspeed = -gravity; //�c���̑��x�����R�ɕύX

        if (isGround)//�ڒn���Ă���Ƃ�
        {
            jumpflag = false;
            if (iy > 0)//Jump�L�[�������ꂽ�Ƃ�
            {
                yspeed = jumpspeed;
                jumpPos = transform.position.y; //�W�����v�����ʒu�iy���j���L�^
                jumpflag = true;
            }
            else
            {
                jumpflag = false;
            }
        }
        else if (jumpflag) //�ڒn���Ă��Ȃ��Ƃ��i�W�����v���Ă���Ƃ��j
        {
            //Jump�L�[true���A���Ԃ��Ă��Ȃ����A���������ȉ��ŃW�����v�p��
            if (iy > 0 && jumpHeight > transform.position.y - jumpPos && !isHead)
            {
                yspeed = jumpspeed;
            }
            else
            {
                jumpflag = false;
            }
        } 

        if (ix != 0) //�ړ���
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

            if (ix < 0) //��
            {
                transform.localScale = new Vector3(-5, 5, 1);
                xspeed = runspeed * ix;
            }
            else //�E
            {
                transform.localScale = new Vector3(5, 5, 1);
                xspeed = runspeed * ix;
            }
        }
        else //��~��
        {
            anim.SetBool("run", false);
            xspeed = 0.0f;
        }
        anim.SetBool("jump",jumpflag);
        anim.SetBool("ground", isGround);
        if (ActSceneMG.startflag) //�Q�[���J�n���Ȃ�
        {
            rb.velocity = new Vector2(xspeed, yspeed); //�s��
        }
    }
}
