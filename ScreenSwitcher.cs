using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    //screens
    public GameObject MainScreen;
    public GameObject Settings;
    public GameObject PrestigeScreen;
    public GameObject Challenges;
    public GameObject PainterScreen;
    public GameObject SecretScreen;

    //screens
    public void GoToMainScreen()
    {
        MainScreen.gameObject.SetActive(true);
    }
    public void GoToSettings()
    {
        Settings.gameObject.SetActive(true);
    }
    public void GoBackFromSettings()
    {
        Settings.gameObject.SetActive(false);
    }
    public void GoToPrestige()
    {
        PrestigeScreen.gameObject.SetActive(true);
    }
    public void GoBackFromPrestige()
    {
        PrestigeScreen.gameObject.SetActive(false);
    }
    public void GoToChallenges()
    {
        Challenges.gameObject.SetActive(true);
    }
    public void GoBackFromChallenges()
    {
        Challenges.gameObject.SetActive(false);
    }
    public void GoToPainterScreen()
    {
        PainterScreen.gameObject.SetActive(true);
    }
    public void GoBackFromPainterScreen()
    {
        PainterScreen.gameObject.SetActive(false);
    }
    public void GoToSecretScreen()
    {
        SecretScreen.gameObject.SetActive(true);
    }
    public void GoBackFromSecretScreen()
    {
        SecretScreen.gameObject.SetActive(false);
    }
}
