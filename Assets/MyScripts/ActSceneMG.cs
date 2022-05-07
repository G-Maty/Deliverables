using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActSceneMG : MonoBehaviour
{
    //�������Ԃ̃Z�b�g
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
        timeUI.text = timer.ToString("0") + "�b";
        StartCoroutine(StartCount());
    }

    // Update is called once per frame
    void Update()
    {
        if (startflag)
        {
            // �������ԂƂ̍����擾���Â���
            timer -= Time.deltaTime;

            if (timer >= 0)
            {
                // ������ɕϊ����ĕ\��
                timeUI.text = timer.ToString("0") + "�b";
            }

            if (timer < 0)
            {
                startflag = false;
                FadeManager.Instance.LoadScene("GameOverScene", 0.3f);
            }
        }
    }

    //�J�n�O�J�E���g�_�E���p�̃R���[�`��
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
