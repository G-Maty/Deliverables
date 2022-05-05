using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProの操作に必要

public class itemManager : MonoBehaviour
{
    private string itemTag = "apple";
    private int itemnum = 5;
    private bool goalflag = false;

    [SerializeField]
    private TextMeshProUGUI itemnumgui;


    // Start is called before the first frame update
    void Start()
    {
        itemnumgui.text = itemnum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == itemTag)
        {
            Destroy(collision.gameObject); //衝突してきたcollisionを持つオブジェクトを削除
            if(itemnum > 0)
            {
                itemnum--;
                itemnumgui.text = itemnum.ToString();
                if(itemnum == 0)
                {
                    goalflag = true;
                    Debug.Log("獲得");
                }
            }
        }

        if(collision.tag == "Finish" && goalflag == true)
        {
            Debug.Log("クリア");
        }

    }
}
