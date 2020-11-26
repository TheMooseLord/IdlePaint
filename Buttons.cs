using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;

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
        if (game.data.paint >= 7.28e3)
        {
            game.data.paint -= game.data.nextColorsCost;
            NextButtons.gameObject.SetActive(true);
            MoreColorsButton.gameObject.SetActive(false);
        }
    }

    //red
    public void BuyColorUpgrade1()
    {
        if (game.data.paint >= game.data.colorUpgradeCost[0])
        {
            game.data.colorUpgradeLevel[0]++;
            game.data.paint -= game.data.colorUpgradeCost[0];
            game.data.colorUpgradeCost[0] *= 1.13;
        }
    }

    //orange
    public void BuyColorUpgrade2()
    {
        if (game.data.paint >= game.data.colorUpgradeCost[1])
        {
            game.data.colorUpgradeLevel[1]++;
            game.data.paint -= game.data.colorUpgradeCost[1];
            game.data.colorUpgradeCost[1] *= 1.17;
        }
    }

    //yellow
    public void BuyColorUpgrade3()
    {
        if (game.data.paint >= game.data.colorUpgradeCost[2])
        {
            game.data.colorUpgradeLevel[2]++;
            game.data.paint -= game.data.colorUpgradeCost[2];
            game.data.colorUpgradeCost[2] *= 1.21;
        }
    }

    //green
    public void BuyColorUpgrade4()
    {
        if (game.data.paint >= game.data.colorUpgradeCost[3])
        {
            game.data.colorUpgradeLevel[3]++;
            game.data.paint -= game.data.colorUpgradeCost[3];
            game.data.colorUpgradeCost[3] *= 1.41;
        }
    }

    //blue
    public void BuyColorUpgrade5()
    {
        if (game.data.paint >= game.data.colorUpgradeCost[4])
        {
            game.data.colorUpgradeLevel[4]++;
            game.data.paint -= game.data.colorUpgradeCost[4];
            game.data.colorUpgradeCost[4] *= 1.46;
        }
    }

    //purple
    private static bool flag;
    public void BuyColorUpgrade6()
    {
        if (game.data.paint >= game.data.colorUpgradeCost[5])
        {
            game.data.colorUpgradeLevel[5]++;
            game.data.paint -= game.data.colorUpgradeCost[5];
            game.data.colorUpgradeCost[5] *= 1.51;
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

            game.data.colorUpgradePower[0] = 1 * game.data.dyeBoost;
            game.data.colorUpgradeLevel[0] = 0 * game.data.dyeBoost; ;
            game.data.colorUpgradeCost[0] = 10;

            game.data.colorUpgradePower[1] = 5 * game.data.dyeBoost; ;
            game.data.colorUpgradeLevel[1] = 0 * game.data.dyeBoost; ;
            game.data.colorUpgradeCost[1] = 25;

            game.data.colorUpgradePower[2] = 25 * game.data.dyeBoost; ;
            game.data.colorUpgradeLevel[2] = 0 * game.data.dyeBoost; ;
            game.data.colorUpgradeCost[2] = 125;

            game.data.colorUpgradePower[3] = 20000 * game.data.dyeBoost; ;
            game.data.colorUpgradeLevel[3] = 0 * game.data.dyeBoost; ;
            game.data.colorUpgradeCost[3] = 65000;

            game.data.colorUpgradePower[4] = 100000 * game.data.dyeBoost; ;
            game.data.colorUpgradeLevel[4] = 0 * game.data.dyeBoost; ;
            game.data.colorUpgradeCost[4] = 200000;

            game.data.colorUpgradePower[5] = 225000 * game.data.dyeBoost; ;
            game.data.colorUpgradeLevel[5] = 0 * game.data.dyeBoost; ;
            game.data.colorUpgradeCost[5] = 500000;

            game.data.dye += game.data.dyeToGet;
            game.data.dyeToGet = 0;
        }
    }

    public void BuyPaintBoost()
    {
        if (game.data.dye >= game.data.paintBoostCost)
        {
            game.data.dye -= game.data.paintBoostCost;
            game.data.paintBoostCost *= 1.41;
            game.data.paintBoost *= 1.07;

            game.data.colorUpgradeLevel[0] *= 1.07;
            game.data.colorUpgradeLevel[1] *= 1.07;
            game.data.colorUpgradeLevel[2] *= 1.07;
            game.data.colorUpgradeLevel[3] *= 1.07;
            game.data.colorUpgradeLevel[4] *= 1.07;
            game.data.colorUpgradeLevel[5] *= 1.07;

            game.data.colorUpgradePower[0] *= 1.07;
            game.data.colorUpgradePower[1] *= 1.07;
            game.data.colorUpgradePower[2] *= 1.07;
            game.data.colorUpgradePower[3] *= 1.07;
            game.data.colorUpgradePower[4] *= 1.07;
            game.data.colorUpgradePower[5] *= 1.07;
        }
    }

    public void BuyDyeBoost()
    {
        if (game.data.dye >= game.data.dyeBoostCost)
        {
            game.data.dye -= game.data.dyeBoostCost;
            game.data.dyeBoostCost *= 1.41;
            game.data.dyeBoost *= 1.41;
        }
    }
}
