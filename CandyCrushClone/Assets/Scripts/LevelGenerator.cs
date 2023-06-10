using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGenerator : MonoSingleton<LevelGenerator>
{
    public const float detectionMultiplier = 25f;

    [SerializeField]
    private Texture2D map;

    [SerializeField]
    private ColorToPrefab[] colorMappings;

    private void Start()
    {
        //CandyManager.singleton.SetWidthAndHeight(map.width, map.height);
        //MatchManager.singleton.SetWidthAndHeight(map.width, map.height);
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }

        //MatchManager.singleton.CheckMatches();
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        for (int i = 0; i < colorMappings.Length; i++)
        {
            float redDifference = Mathf.Abs(colorMappings[i].color.r - pixelColor.r) * 255;
            float greenDifference = Mathf.Abs(colorMappings[i].color.g - pixelColor.g) * 255;
            float blueDifference = Mathf.Abs(colorMappings[i].color.b - pixelColor.b) * 255;

            float totalDifference = redDifference + greenDifference + blueDifference;

            //Debug.Log("TD: " + totalDifference + " PN: " + colorMappings[i].prefab.name);

            if (totalDifference < detectionMultiplier)
            {
                Vector2 generatePosition = new Vector2(x, y);

                GameObject generatedCandy = Instantiate(colorMappings[i].prefab, generatePosition,
                    Quaternion.identity);

                //CandyManager.singleton.AddCandy(generatedCandy, x, y);
            }
        }
    }
}
