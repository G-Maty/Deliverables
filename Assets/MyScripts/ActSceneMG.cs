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

    // Start is called before the first frame update
    void Start()
    {
        timer = rouletteManager.timelimit;
        timeUI.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // �������ԂƂ̍����擾���Â���
        timer -= Time.deltaTime;

        if (timer >= 0)
        {
            // ������ɕϊ����ĕ\��
            timeUI.text = timer.ToString("0");
        }
    }
}
