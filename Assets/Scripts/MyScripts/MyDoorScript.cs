using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyDoorScript : MonoBehaviour
{
    private bool isLocked = true;

    public Material doorMaterial;

    
    // Toggle bool and update door material for feedback
    public void UpdateToggle()
    {
        isLocked = !isLocked;

        if (isLocked)
        {
            doorMaterial.color = Color.red;
        }
        else
        {
            doorMaterial.color = Color.green;
        }
    }
    
    // If door is not locked and player enters, end game
    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked && other.gameObject.CompareTag("character"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
