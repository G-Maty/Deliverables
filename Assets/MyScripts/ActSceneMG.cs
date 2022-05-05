using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActSceneMG : MonoBehaviour
{
    //制限時間のセット
    private float timer;
    [SerializeField]
    private TextMeshProUGUI timeUI;

    // Start is called before the first frame update
    void Start()
    {
        timer = rouletteManager.timelimit;
        timeUI.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // 制限時間との差を取得しつづける
        timer -= Time.deltaTime;

        if (timer >= 0)
        {
            // 文字列に変換して表示
            timeUI.text = timer.ToString("0");
        }
    }
}
