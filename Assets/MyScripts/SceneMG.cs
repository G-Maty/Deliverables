using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMG : MonoBehaviour
{
    public void move_MainScene()
    {
        FadeManager.Instance.LoadScene("MainScene", 0.3f);
    }

    public void move_ActionScene()
    {
        FadeManager.Instance.LoadScene("ActionScene", 0.3f);
    }

    public void move_GameOverScene()
    {
        FadeManager.Instance.LoadScene("GameOverScene", 0.3f);
    }

    public void move_RouletteScene()
    {
        FadeManager.Instance.LoadScene("RouletteScene", 0.3f);
    }

    public void move_HowToScene()
    {
        FadeManager.Instance.LoadScene("HowToScene", 0.3f);
    }
}
