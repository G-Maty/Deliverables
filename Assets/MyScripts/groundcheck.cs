using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    //���ӁF���̃X�v���N�g�����ǂ������������邪�A��Փx���������ߑË���
    private string groundTag = "Ground";
    private bool isground = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //�ڒn�����Ԃ����\�b�h
    //��������̍X�V���ƂɌĂԕK�v������
    public bool IsGround()
    {
        if(isGroundEnter || isGroundStay)
        {
            isground = true;
        }
        else if (isGroundExit)
        {
            isground = false;
        }

        //�Ō�Ɋe��̃t���O�����낷
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        //�ڒn�����Ԃ�
        return isground;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
    }
}
