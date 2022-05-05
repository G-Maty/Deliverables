using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouSceneMG : MonoBehaviour
{
    public void moveActionScene()
    {
        FadeManager.Instance.LoadScene("ActionScene", 0.3f);
    }

    public void moveRouletteScene()
    {
        FadeManager.Instance.LoadScene("RouletteScene", 0.3f);
    }
}
