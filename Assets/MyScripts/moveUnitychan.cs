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
    private float ix = 0; //Horizontal�L�[�̓��͌��ʂ�ێ�(-1 �` 1)
    private float iy = 0; //Jump�L�[�̓��͌��ʂ�ێ�(-1 �` 1)
    private Animator anim;
    [SerializeField]
    private float runspeed = 10.0f; //����ő呬�x
    [SerializeField]
    private float jumpforce = 700f; //��Ԃ��߂ɉ������
    private bool jumpflag = false;

    //�ڒn����(�v���C���[���̓ǂݍ���)
    public groundcheck ground;
    private bool isGround = false;


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

        ix = Input.GetAxis("Horizontal");
        iy = Input.GetAxis("Jump");
        float xspeed = runspeed;

        if (isGround)//�ڒn���Ă���Ƃ�
        {
            jumpflag = false;
            anim.SetBool("jump", false);
            if (iy > 0)//Jump�L�[�������ꂽ�Ƃ�
            {
                anim.SetBool("jump",true);
                rb.AddForce(transform.up * jumpforce); //transform.up�͒����P�̏�����x�N�g���itransform.up = (0,1,0) �j
                jumpflag = true;
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
        rb.velocity = new Vector2(xspeed, rb.velocity.y); //�s��
    }
}
