﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StageCode
{
    Level1_Stage1, Level1_Stage2, Level1_Stage3,
    Level2_Stage1, Level2_Stage2, Level2_Stage3,
    Level3_Stage1, Level3_Stage2, Level3_Stage3,
    Level4_Stage1, Level4_Stage2, Level4_Stage3
}

public class StageSelection : MonoBehaviour
{
    private int numLevels = 4;  // each level has 3 stages
    private int numStages = 3;  // each stage belongs to one level
    private Color starColor = new Color(1f, 0.77f, 0.03f);
    private string[] stageCodes;

    void Awake()
    {
        stageCodes = System.Enum.GetNames(typeof(StageCode));
        GameObject[] stars = GameObject.FindGameObjectsWithTag("StageStar");
        //test();

        for (int lvl=0; lvl < numLevels; lvl++)
        {
            int[] numStars = new int[3];

            for (int stg=0; stg < numStages; stg++)
            {
                // get number of stars for each level
                numStars[stg] = PlayerPrefs.GetInt(stageCodes[lvl * numStages + stg], 0);

                // display how many stars each stage has
                int starsPerStage = 3;
                int starsPerLevel = 9;
                for(int i=0; i < numStars[stg]; i++)
                {
                    stars[lvl * starsPerLevel + stg * starsPerStage + i]
                        .GetComponent<Image>().color = starColor;
                }
            }

            // Unlock a level based on number of stars it has (except last level)
            if (lvl < (numLevels-1) && numStars[0] + numStars[1] + numStars[2] >= 6)
                transform.Find("Level " + (lvl + 2) + " Cover").gameObject.SetActive(false);

            // if a player gets all stars for a level, display a medal
            if (numStars[0] + numStars[1] + numStars[2] == 9)
                transform.Find("Level " + (lvl + 1) + "/Medal").gameObject.SetActive(true);
        }    
    }

    private void test()
    {
        PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt(stageCodes[0], 3);
        //PlayerPrefs.SetInt(stageCodes[1], 3);
        //PlayerPrefs.SetInt(stageCodes[2], 3);

        //PlayerPrefs.SetInt(stageCodes[3], 2);
        //PlayerPrefs.SetInt(stageCodes[4], 0);
        //PlayerPrefs.SetInt(stageCodes[5], 0);

        //PlayerPrefs.SetInt(stageCodes[6], 0);
        //PlayerPrefs.SetInt(stageCodes[7], 0);
        //PlayerPrefs.SetInt(stageCodes[8], 0);

        //PlayerPrefs.SetInt(stageCodes[9], 0);
        //PlayerPrefs.SetInt(stageCodes[10], 0);
        //PlayerPrefs.SetInt(stageCodes[11], 0);
    }
}