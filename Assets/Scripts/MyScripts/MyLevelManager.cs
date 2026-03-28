using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLevelManager : MonoBehaviour
{
    // References
    public UIManager uiManager;
    public FearManager fearManager;
    public HallwayScript hallwayScript;
    public Character player;
    public MyDoorScript door;
    public WallBarrier wallBarrier;
    public AudioManager audioManager;
    
    void Start()
    {
        // Fear manager listeners
        fearManager.OnMaxFear.AddListener(EndLevel);
        fearManager.OnMaxFear.AddListener(audioManager.MaxFearSound);
        fearManager.OnFearChanged.AddListener(uiManager.UpdatePlayerFear);
        
        // Player listeners
        player.OnLanternToggle.AddListener(fearManager.ToggleFearState);
        player.OnLanternToggle.AddListener(door.UpdateToggle);
        player.OnLanternToggle.AddListener(hallwayScript.ToggleHallwayColor);
        player.OnLanternToggle.AddListener(wallBarrier.ToggleState);
        
        // Hallway script listeners
        hallwayScript.OnEnterHallway.AddListener(fearManager.ToggleInHallway);
        hallwayScript.OnEnterHallway.AddListener(audioManager.EnterHallwaySound);
            
        hallwayScript.OnExitHallway.AddListener(fearManager.ToggleInHallway);
        hallwayScript.OnEnterHallway.AddListener(audioManager.ExitHallwaySound);
    }
    
    // Ends level upon max fear reached
    void EndLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}
