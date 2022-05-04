using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteManager : MonoBehaviour
{
    [SerializeField]
    private float rotspeed = 100;
    private int stop = 0;
    private bool rotflag = false;
    private float angl = 0;

    public GameObject rolette1;
    public GameObject rolette2;
    public GameObject rolette3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0) && rotflag == false)
        {
            this.rotspeed = 100;
            rotflag = true;
        }
        */
        rolette1.transform.Rotate(0, 0, rotspeed);
        rolette2.transform.Rotate(0, 0, rotspeed);
        rolette3.transform.Rotate(0, 0, rotspeed);

        /*
        rotspeed *= 0.98f;
        transform.Rotate(0, 0, this.rotspeed);
        stop = (int)(rotspeed * 100);

        if (stop == 0 && rotflag == true)
        {
            Debug.Log("stop");
            rotflag = false;
            angl = this.transform.eulerAngles.z;
            if (angl >= 0 && angl < 90)
            {
                Debug.Log("A");
            }
            else if (angl >= 90 && angl < 180)
            {
                Debug.Log("B");
            }
            else if (angl >= 180 && angl < 270)
            {
                Debug.Log("C");
            }
            else
            {
                Debug.Log("D");
            }
        }
        */
    }
}
