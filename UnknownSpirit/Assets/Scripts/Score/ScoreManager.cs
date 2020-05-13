using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<float> HighScores;

    string path = @"Assets/Resources/ScoreData/Scores.txt";

    public ScoreManager()
    {
        HighScores = new List<float>();
    }

    public void AddScoreToList(float score)
    {
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(score);
        }

        SortTextFile();
    }

    void SortTextFile()
    {
        string[] lines = File.ReadAllLines(path);

        foreach (var item in lines)
        {
            float f = float.Parse(item);
            HighScores.Add(f);
        }

        HighScores.Sort();
    }
}
