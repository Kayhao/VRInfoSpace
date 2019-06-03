using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBind : MonoBehaviour {

    private VRIK vrik;

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
        
    }
}
