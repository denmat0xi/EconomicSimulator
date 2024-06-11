using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Dictionary<string, int> softSkillsOfPeople;
    private Dictionary<string, int> hardSkillsOfPeople;
    private int sumOfSkills;
    private string mail;
    private string name;

    public Human(int value, string nameOfPerson, string mailOfPerson, Dictionary<string, int> hardSkills)
    {
        sumOfSkills = value;
        mail = mailOfPerson;
        name = nameOfPerson;
        hardSkillsOfPeople = hardSkills;
    }

    public int GetSoftValue(string key)
    {
        return softSkillsOfPeople.TryGetValue(key, out int value) ? value : throw new KeyNotFoundException($"Ключ {key} не найден в словаре.");
    }

    public void setHardSkills(Dictionary<string, int> target)
    {
        hardSkillsOfPeople = target;
    }

    public string getName()
    {
        return name;
    }

    public string GetResume()
    {
        var average = 0;
        var answer = "";
        answer += name + '\n';
        answer += mail + '\n';
        foreach (var item in hardSkillsOfPeople)
        {
            average += item.Value;
        }
        average /= hardSkillsOfPeople.Count;
        foreach (var item in hardSkillsOfPeople)
        {
            answer += item.Key + ":" + " " + item.Value + '\n';
        }
        return answer;
    }
}
