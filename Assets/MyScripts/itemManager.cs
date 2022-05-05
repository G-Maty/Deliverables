using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProの操作に必要

public class itemManager : MonoBehaviour
{
    private string itemTag = "grape";
    private int itemnum = 5;
    private bool goalflag = false;

    [SerializeField]
    private TextMeshProUGUI itemnumgui;
    
    [SerializeField][Tooltip("apple")]
    private GameObject appleUI;
    [SerializeField][Tooltip("grape")]
    private GameObject grapeUI;
    [SerializeField][Tooltip("banana")]
    private GameObject bananaUI;
    [SerializeField][Tooltip("cherry")]
    private GameObject cherryUI;



    // Start is called before the first frame update
    void Start()
    {
        itemTag = rouletteManager.fruitname;
        itemnum = rouletteManager.amountitems;
        itemnumgui.text = itemnum.ToString();

        if(itemTag == "apple")
        {
            appleUI.SetActive(true);
        }
        else if(itemTag == "grape")
        {
            grapeUI.SetActive(true);
        }
        else if(itemTag == "banana")
        {
            bananaUI.SetActive(true);
        }
        else
        {
            cherryUI.SetActive(true);
        }
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
                }
            }
        }

        if(collision.tag == "Finish" && goalflag == true)
        {
            Debug.Log("クリア");
        }

    }
}
