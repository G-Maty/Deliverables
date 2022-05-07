using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rouletteManager : MonoBehaviour
{
    [SerializeField]
    private float rot1speed = 100, rot2speed = 100, rot3speed = 100;
    [SerializeField]
    private GameObject ConfirmWindow; //確認画面
    private int stop1 = 0, stop2 = 0, stop3 = 0;
    private bool rot1flag = false, rot2flag = false, rot3flag = false;
    private float angl1 = 0, angl2 = 0, angl3 = 0;
    [SerializeField]
    private TextMeshProUGUI amountUI;
    [SerializeField]
    private TextMeshProUGUI timeUI;
    [SerializeField][Tooltip("apple")]
    private GameObject appleUI;
    [SerializeField][Tooltip("grape")]
    private GameObject grapeUI;
    [SerializeField][Tooltip("banana")]
    private GameObject bananaUI;
    [SerializeField][Tooltip("cherry")]
    private GameObject cherryUI;

    public GameObject roulette1;
    public GameObject roulette2;
    public GameObject roulette3;

    //共有変数
    public static string fruitname; //フルーツ名
    public static int amountitems; //量
    public static float timelimit; //制限時間

    // Start is called before the first frame update
    void Start()
    {
        ConfirmWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ルーレット１の挙動
        if(rot1flag == false)
        {
            roulette1.transform.Rotate(0, 0, rot1speed);
        }
        else
        {
            rot1speed *= 0.98f;
            roulette1.transform.Rotate(0, 0, rot1speed);
        }
        //ルーレット２の挙動
        if (rot2flag == false)
        {
            roulette2.transform.Rotate(0, 0, rot2speed);
        }
        else
        {
            rot2speed *= 0.98f;
            roulette2.transform.Rotate(0, 0, rot2speed);
        }
        //ルーレット３の挙動
        if (rot3flag == false)
        {
            roulette3.transform.Rotate(0, 0, rot3speed);
        }
        else
        {
            rot3speed *= 0.98f;
            roulette3.transform.Rotate(0, 0, rot3speed);
        }

        stop1 = (int)(rot1speed * 100);
        stop2 = (int)(rot2speed * 100);
        stop3 = (int)(rot3speed * 100);

        //結果表示
        if (stop1 == 0 && rot1flag == true)
        {
            angl1 = roulette1.transform.eulerAngles.z;
            roulette1.transform.Rotate(0, 0, 0);
            if (angl1 >= 0 && angl1 < 90)
            {
                fruitname = "cherry";
            }
            else if (angl1 >= 90 && angl1 < 180)
            {
                fruitname = "banana";
            }
            else if (angl1 >= 180 && angl1 < 270)
            {
                fruitname = "apple";
            }
            else
            {
                fruitname = "grape";
            }
        }

        if (stop2 == 0 && rot2flag == true)
        {
            angl2 = roulette2.transform.eulerAngles.z;
            roulette2.transform.Rotate(0, 0, 0);
            if (angl2 >= 0 && angl2 < 90)
            {
                amountitems = 2;
            }
            else if (angl2 >= 90 && angl2 < 180)
            {
                amountitems = 4;
            }
            else if (angl2 >= 180 && angl2 < 270)
            {
                amountitems = 6;
            }
            else
            {
                amountitems = 8;
            }
        }

        if(stop3 == 0 && rot3flag == true)
        {
            angl3 = roulette3.transform.eulerAngles.z;
            roulette3.transform.Rotate(0, 0, 0);
            if (angl3 > 180 && angl3 <= 317.3)
            {
                timelimit = 60f;
            }else if(angl3 > 38.5 && angl3 <= 180)
            {
                timelimit = 40f;
            }
            else
            {
                timelimit = 20f;
            }
        }

        if(stop1 == 0 && stop2 == 0 && stop3 == 0)
        {
            ConfirmWindow.SetActive(true);
            amountUI.text = "×" + amountitems.ToString() + "つ";
            timeUI.text = "制限時間" + timelimit.ToString() + "s";
            if (fruitname == "apple")
            {
                appleUI.SetActive(true);
                grapeUI.SetActive(false);
                bananaUI.SetActive(false);
                cherryUI.SetActive(false);
            }
            else if (fruitname == "grape")
            {
                appleUI.SetActive(false);
                grapeUI.SetActive(true);
                bananaUI.SetActive(false);
                cherryUI.SetActive(false);
            }
            else if (fruitname == "banana")
            {
                appleUI.SetActive(false);
                grapeUI.SetActive(false);
                bananaUI.SetActive(true);
                cherryUI.SetActive(false);
            }
            else
            {
                appleUI.SetActive(false);
                grapeUI.SetActive(false);
                bananaUI.SetActive(false);
                cherryUI.SetActive(true);
            }
        }
    }

    public void roulette1_stop(GameObject obj)
    {
        rot1flag = true;
        obj.SetActive(false);
    }

    public void roulette2_stop(GameObject obj)
    {
        rot2flag = true;
        obj.SetActive(false);
    }

    public void roulette3_stop(GameObject obj)
    {
        rot3flag = true;
        obj.SetActive(false);
    }
}
