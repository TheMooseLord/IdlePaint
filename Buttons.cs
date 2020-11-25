using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Main game;
    public ScreenSwitcher screen;
    public GameObject NextButtons;
    public GameObject MoreColorsButton;
    public GameObject NextPanel;

    //more colors
    public void MoreColors()
    {
        if (game.data.paint >= 15000)
        {
            game.data.paint -= game.data.nextColorsCost;
            NextButtons.gameObject.SetActive(true);
            MoreColorsButton.gameObject.SetActive(false);
        }
    }

    //red
    public void BuyRedUpgrade()
    {
        if (game.data.paint >= game.data.redUpgradeCost)
        {
            game.data.redUpgradeLevel++;
            game.data.paint -= game.data.redUpgradeCost;
            game.data.redUpgradeCost *= 1.13;
        }
    }

    //orange
    public void BuyOrangeUpgrade()
    {
        if (game.data.paint >= game.data.orangeUpgradeCost)
        {
            game.data.orangeUpgradeLevel++;
            game.data.paint -= game.data.orangeUpgradeCost;
            game.data.orangeUpgradeCost *= 1.17;
        }
    }

    //yellow
    public void BuyYellowUpgrade()
    {
        if (game.data.paint >= game.data.yellowUpgradeCost)
        {
            game.data.yellowUpgradeLevel++;
            game.data.paint -= game.data.yellowUpgradeCost;
            game.data.yellowUpgradeCost *= 1.21;
        }
    }

    //green
    public void BuyGreenUpgrade()
    {
        if (game.data.paint >= game.data.greenUpgradeCost)
        {
            game.data.greenUpgradeLevel++;
            game.data.paint -= game.data.greenUpgradeCost;
            game.data.greenUpgradeCost *= 1.41;
        }
    }

    //blue
    public void BuyBlueUpgrade()
    {
        if (game.data.paint >= game.data.blueUpgradeCost)
        {
            game.data.blueUpgradeLevel++;
            game.data.paint -= game.data.blueUpgradeCost;
            game.data.blueUpgradeCost *= 1.46;
        }
    }

    //purple
    private static bool flag;
    public void BuyPurpleUpgrade()
    {
        if (game.data.paint >= game.data.purpleUpgradeCost)
        {
            game.data.purpleUpgradeLevel++;
            game.data.paint -= game.data.purpleUpgradeCost;
            game.data.purpleUpgradeCost *= 1.51;

            if (!flag) NextPanel.gameObject.SetActive(flag = true);
        }
    }


    //Prestige
    public void CollectDye()
    {
        if (game.data.paint >= 1e5)
        {

            //paint
            game.data.paint = 10;
            game.data.paintPerSecond = 0;
            game.data.nextColorsCost = 15000;

            //red
            game.data.redUpgradePower = 1;
            game.data.redUpgradeLevel = 0;
            game.data.redUpgradeCost = 10;
            //orange
            game.data.orangeUpgradePower = 5;
            game.data.orangeUpgradeLevel = 0;
            game.data.orangeUpgradeCost = 25;
            //yellow
            game.data.yellowUpgradePower = 25;
            game.data.yellowUpgradeLevel = 0;
            game.data.yellowUpgradeCost = 125;
            //green
            game.data.greenUpgradePower = 20000;
            game.data.greenUpgradeLevel = 0;
            game.data.greenUpgradeCost = 65000;
            //blue
            game.data.blueUpgradePower = 100000;
            game.data.blueUpgradeLevel = 0;
            game.data.blueUpgradeCost = 200000;
            //purple
            game.data.purpleUpgradePower = 225000;
            game.data.purpleUpgradeLevel = 0;
            game.data.purpleUpgradeCost = 500000;

            game.data.dye += game.data.dyeToGet;
        }
    }

    public void BuyPaintBoost()
    {
        if (game.data.dye >= game.data.paintBoostCost)
        {
            game.data.dye -= game.data.paintBoostCost;
            game.data.paintBoostCost *= 1.41;

            game.data.redUpgradeLevel *= 1.07;
            game.data.orangeUpgradeLevel *= 1.07;
            game.data.yellowUpgradeLevel *= 1.07;
            game.data.greenUpgradeLevel *= 1.07;
            game.data.blueUpgradeLevel *= 1.07;
            game.data.purpleUpgradeLevel *= 1.07;

            game.data.redUpgradePower *= 1.07;
            game.data.orangeUpgradePower *= 1.07;
            game.data.yellowUpgradePower *= 1.07;
            game.data.greenUpgradePower *= 1.07;
            game.data.blueUpgradePower *= 1.07;
            game.data.purpleUpgradePower *= 1.07;
        }
    }
}
