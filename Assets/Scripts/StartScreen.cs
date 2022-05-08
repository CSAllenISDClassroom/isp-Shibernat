using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //Creates option to apply to the "Play" button 
    public void LoadGame() 
    {
        //Switches scene by adding one to the scene index
        //The menu has an index of 0 and the game scene has an index of 1, so having +1 would switch the menu to the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Creates option to apply to the "Quit" button
    public void QuitGame()
    {
        //Shows message in log when used
        Debug.Log ("QUIT!");
        Application.Quit();
    }
}
