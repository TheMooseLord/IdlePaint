using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public Main game;
    public Buttons button;
    public static bool fullScreen;

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void FullReset()
    {
        game.data.FullReset();
        button.NextButtons.gameObject.SetActive(false);
        button.MoreColorsButton.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }





    public int[,] screenResolutionArray = {
        {1920, 1080},
        {5120, 2880},
        {1600,  900},
        {1536,  864},
        {1440,  900},
        {1366,  768},
        {1280, 1024},
        {1280,  800},
        {1280,  720},
        {1024,  768}
    };



    public void SwitchResolutionType()
    {
        if (game.data.screenResolutionIndex >= 8) game.data.screenResolutionIndex = -1;
        game.data.screenResolutionIndex++;
        int i = game.data.screenResolutionIndex;
        Screen.SetResolution(screenResolutionArray[i, 0], screenResolutionArray[i, 1], true);
    }
}
