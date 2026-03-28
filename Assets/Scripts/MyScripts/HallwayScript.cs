using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HallwayScript : MonoBehaviour
{
    private Material hallwayMaterial;
    
    public bool isHallwayDark;

    private Color darkHallwayColor;
    private Color lightHallwayColor;

    [HideInInspector] 
    public UnityEvent OnDarkHallway;
    
    [HideInInspector] 
    public UnityEvent OnEnterHallway;
    
    [HideInInspector] 
    public UnityEvent OnExitHallway;
    
    void Start()
    {
        // Create unity events
        if (OnDarkHallway == null)
            OnDarkHallway = new UnityEvent();
        
        if (OnEnterHallway == null)
            OnEnterHallway = new UnityEvent();
        
        if (OnExitHallway == null)
            OnExitHallway = new UnityEvent();
        
        // Get hallway material
        hallwayMaterial = GetComponent<MeshRenderer>().material;
        
        darkHallwayColor = hallwayMaterial.color;
        lightHallwayColor = hallwayMaterial.color;
        lightHallwayColor.a = 0.3f;
    }
    
    public void ToggleHallwayColor()
    {
        isHallwayDark = !isHallwayDark;

        if (isHallwayDark)
        {
            hallwayMaterial.color = darkHallwayColor;
        }
        else
        {
            hallwayMaterial.color = lightHallwayColor;
        }
    }

    // If player enters hallway, invoke
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("character"))
        {
            //ToggleHallwayColor();
            OnEnterHallway.Invoke();
        }
    }

    // If player exits hallway, invoke
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("character"))
        {
            OnExitHallway.Invoke();
        }
    }
}
