using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    private int allPoints;
    private int pointsToEnd;
    private List<Task> tasks;
    private List<string> requirements;

    public void everyDay(int points)
    {
        if(points >= pointsToEnd)
        {
            pointsToEnd = 0;
        } 
        else
        {
            pointsToEnd -= points;
        }
    }

    public int getPercentage()
    {
        return (allPoints - pointsToEnd) / allPoints;
    }
}
