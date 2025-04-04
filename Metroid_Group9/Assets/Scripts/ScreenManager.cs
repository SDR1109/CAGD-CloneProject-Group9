using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: Maya Andrade
 * Date: 04/03/25
 * Last Updated: 04/03/25
 * Description: Allows buttons to function to switch to different scenes
 */

public class ScreenManager : MonoBehaviour
{
    /*
     * Scene Build Order:
     * Main Menu = 0
     * Tutorial = 1
     * Metroid Level = 2
     * Game Over = 3
     * Game Won = 4
     */


    /// <summary>
    /// When a button with this function is pressed, it takes the player to the main menu screen
    /// </summary>
    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// When a button with this function is pressed, it takes the player to the tutorial level
    /// </summary>
    public void TutorialButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// When a button with this function is pressed, it takes the player to the beginning of the main game (to play through levels)
    /// </summary>
    public void PlayGameButtonPressed()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// When a button with this function is pressed, it closes out the game (quits the game... obvi)
    /// </summary>
    public void QuitButtonPressed()
    {
        print("Quit Game");
        Application.Quit();
    }   
    
}
