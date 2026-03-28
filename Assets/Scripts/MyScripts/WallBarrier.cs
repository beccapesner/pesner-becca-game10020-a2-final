using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallBarrier : MonoBehaviour, IBarrier
{
    private bool isBarrierUp = false;
    private Vector3 origin;
    private Vector3 downPosition;

    private void Start()
    {
        origin = transform.position;
        downPosition = origin;
        downPosition.y = -2.0f;
    }
    
    public void ToggleState()
    {
        isBarrierUp = !isBarrierUp;
    }

    private void Update()
    {
        // Move barrier to state position
        if (isBarrierUp)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, origin, Time.deltaTime * 10);
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, downPosition, Time.deltaTime * 10);
        }
    }


}
