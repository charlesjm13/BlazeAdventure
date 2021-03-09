using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList; 


    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = transform.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{score= 487, name= "IUH"},
            new HighscoreEntry{score= 343, name= "DFS"},
            new HighscoreEntry{score= 567, name= "WRE"},
            new HighscoreEntry{score= 528, name= "FSV"},
            new HighscoreEntry{score= 888, name= "QEW"},
            new HighscoreEntry{score= 311, name= "KNL"},
        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container,List<Transform> transformList)
    {
        float templateHeight = 30f;
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTranform = entryTransform.GetComponent<RectTransform>();
            entryRectTranform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryRectTranform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }
            entryTransform.Find("posText").GetComponent<Text>().text = rankString;

            int score = highscoreEntry.score;

            entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

            string name = highscoreEntry.name;
            entryTransform.Find("nameText").GetComponent<Text>().text = name;

            transformList.Add(entryTransform);
        }
    }
    private class HighscoreEntry
    {
        public int score;
        public string name; 

    }

}
