using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public MyLevelManager levelManager;
    public Slider fearSlider;

    // Update player fear
    public void UpdatePlayerFear()
    {
        fearSlider.value = levelManager.fearManager.currentFear / levelManager.fearManager.maxFear;
    }
    
    
    
}
