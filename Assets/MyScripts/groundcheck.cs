using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    //注意：このスプリクトよりも良い書き方があるが、難易度が高いため妥協案
    private string groundTag = "Ground";
    private bool isground = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    //物理判定の更新ごとに呼ぶ必要がある
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

        //最後に各種のフラグを下ろす
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        //接地判定を返す
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
