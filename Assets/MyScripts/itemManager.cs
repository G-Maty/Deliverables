using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro�̑���ɕK�v

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
            Destroy(collision.gameObject); //�Փ˂��Ă���collision�����I�u�W�F�N�g���폜
            if(itemnum > 0)
            {
                itemnum--;
                itemnumgui.text = itemnum.ToString();
                if(itemnum == 0)
                {
                    goalflag = true;
                    Debug.Log("�l��");
                }
            }
        }

        if(collision.tag == "Finish" && goalflag == true)
        {
            Debug.Log("�N���A");
        }

    }
}
