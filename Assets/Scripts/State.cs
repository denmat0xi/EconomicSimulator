using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    private List<Human> workers = new List<Human>();

    public void AddWorker(Human target)
    {
        workers.Add(target);
    }

    public void RemoveWorker(string name)
    {
        var itemToRemove = workers.FirstOrDefault(x => x.getName() == name);
        if (itemToRemove != null) workers.Remove(itemToRemove);
        else throw new Exception("В штате нет такого работника.");
    }

    public string getStateList()
    {
        var answer = "";
        foreach (var worker in workers)
        {
            answer += worker.GetResume() + '\n';
        }

        return answer;
    }
}
