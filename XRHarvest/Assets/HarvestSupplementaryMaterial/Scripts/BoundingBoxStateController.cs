using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class BoundingBoxStateController : MonoBehaviour
{
    
    private BoundsControl boundsControl;
    private ObjectManipulator objectManipulator;

    public void Awake(){
        boundsControl = GetComponent<BoundsControl>();
        objectManipulator = GetComponent<ObjectManipulator>();
    }
    private void Start()
    {
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;
    }

    // Update is called once per frame
    private void OnGameStarted()
    {
        boundsControl.Active = false;
        boundsControl.TargetBounds.enabled = false;
        objectManipulator.enabled = false;
    }

    private void OnGameFinished()
    {
        boundsControl.Active = true;
        boundsControl.TargetBounds.enabled = true;
        objectManipulator.enabled = true;
    }
}