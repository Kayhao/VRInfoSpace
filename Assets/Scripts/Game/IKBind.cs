using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBind : MonoBehaviour {

    private VRIK vrik;
    private bool isLeft=false;
    private bool isRight=false;

    private void Awake()
    {
        vrik = GetComponent<VRIK>();
    }

    private void Start()
    {
        vrik.solver.spine.headTarget = GameObject.FindGameObjectWithTag("NickHead").transform;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("LArmHand")!=null)
        {
            if (isLeft==false)
            {
                vrik.solver.leftArm.target = GameObject.FindGameObjectWithTag("LArmHand").transform;
                isLeft = true;
            }
        }

        if (GameObject.FindGameObjectWithTag("RArmHand") != null)
        {
            if (isRight == false)
            {
                vrik.solver.rightArm.target = GameObject.FindGameObjectWithTag("RArmHand").transform;
                isRight = true;
            }
        }
    }
}
