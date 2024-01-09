using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactorsManager : MonoBehaviour
{
    public bool off;
    public int nbReactors;
    private int nbReactorsTotal;
    public Text ReactorsCount;
    public GameObject exit;
    private bool notCalled;

    void Start()
    {
        notCalled = true;
        nbReactorsTotal = transform.childCount;
    }

    void Update()
    {
        nbReactors = transform.childCount;
        off = (nbReactors == 0);
        ReactorsCount.text = nbReactors + " / " + nbReactorsTotal;
        if (off && notCalled)
        {
            notCalled = false;
            CallExit();
        }
    }

    void CallExit()
    {
        exit.GetComponent<ExitLevel>().OpenExit();
        
    }
}
