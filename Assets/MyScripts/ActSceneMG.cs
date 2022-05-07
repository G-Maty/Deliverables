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
    [SerializeField]
    private TextMeshProUGUI startCount;
    public static bool startflag = false;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timer = rouletteManager.timelimit;
        timeUI.text = timer.ToString("0") + "秒";
        StartCoroutine(StartCount());
    }

    // Update is called once per frame
    void Update()
    {
        if (startflag)
        {
            // 制限時間との差を取得しつづける
            timer -= Time.deltaTime;

            if (timer >= 0)
            {
                // 文字列に変換して表示
                timeUI.text = timer.ToString("0") + "秒";
            }

            if (timer < 0)
            {
                startflag = false;
                FadeManager.Instance.LoadScene("GameOverScene", 0.3f);
            }
        }
    }

    //開始前カウントダウン用のコルーチン
    IEnumerator StartCount()
    {
        startCount.gameObject.SetActive(true);

        startCount.text = "3";
        yield return new WaitForSeconds(1.0f);

        startCount.text = "2";
        yield return new WaitForSeconds(1.0f);

        startCount.text = "1";
        yield return new WaitForSeconds(1.0f);

        startCount.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        startCount.gameObject.SetActive(false);
        startflag = true;
    }
}
