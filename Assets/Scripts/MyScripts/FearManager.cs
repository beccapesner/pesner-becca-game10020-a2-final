using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FearManager : MonoBehaviour
{
    public float currentFear = 0.0f;
    public float maxFear = 100.0f;
    public float fearAddition = 2.0f;
    public bool shouldFearBeAdded = false;

    [HideInInspector] 
    public UnityEvent OnMaxFear;

    [HideInInspector] 
    public UnityEvent OnFearChanged;

    private float previousFear;
    private bool isInHallway = false;
    
    private void Start()
    {
        // Create unity events
        if (OnMaxFear == null)
            OnMaxFear = new UnityEvent();
        
        if (OnFearChanged == null)
            OnFearChanged = new UnityEvent();
    }

    private void Update()
    {
        if (!isInHallway)
            return;
        
        // Get current fear for updating UI
        previousFear =  currentFear;
        
        // Add or remove fear when appropriate
        if (shouldFearBeAdded)
        {
            // If fear is at max, invoke max fear -> ending game
            if (currentFear >= maxFear)
            {
                currentFear = maxFear;
                OnMaxFear.Invoke();
            }
            else
            {
                currentFear += fearAddition * Time.deltaTime;
            }
        }
        else
        {
            // Cap fear min
            if (currentFear <= 0)
            {
                currentFear = 0;
            }
            else
            {
                currentFear -= fearAddition * Time.deltaTime;
            }
        }

        // If fear has changed, invoke UI update
        if (currentFear != previousFear)
        {
            OnFearChanged.Invoke();
        }
    }

    // Toggle between adding and subtracting fear
    public void ToggleFearState()
    {
        shouldFearBeAdded = !shouldFearBeAdded;
    }

    // Keep track if we are in the hallway or not
    public void ToggleInHallway()
    {
        isInHallway = !isInHallway;
    }
}
