using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private List<string> _hardSkills = new List<string>
        {
            "Программирование",
            "Аналитика",
            "Дизайн"
        };

    private static readonly List<string> MalePrefixes = new List<string>
        {
            "Ан",
            "Вал",
            "Влад",
            "Дми",
            "Иван",
            "Кон",
            "Лев",
            "Мих",
            "Ник",
            "Пет",
            "Ром",
            "Сер"
        };
    private static readonly List<string> FemalePrefixes = new List<string>
        {
            "Ан",
            "Вал",
            "Вер",
            "Дар",
            "Ев",
            "Ир",
            "Кат",
            "Лар",
            "Мар",
            "Над",
            "Ол"
        };
    private static readonly List<string> Suffixes = new List<string>
        {
            "а",
            "ина",
            "ка",
            "на",
            "я"
        };

    private static string GenerateName()
    {
        var isMale = Random.Range(0, 1) == 0;
        var prefix = isMale ? MalePrefixes[Random.Range(0, MalePrefixes.Count)] : FemalePrefixes[Random.Range(0, FemalePrefixes.Count)];
        var suffix = Suffixes[Random.Range(0, Suffixes.Count)];
        return prefix + suffix;
    }

    private static string GenerateEmail(string name)
    {
        string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "mail.ru", "yandex.ru" };

        var domain = domains[Random.Range(0, domains.Length)];

        var email = $"{name.Replace(" ", ".").ToLower()}@{domain}";

        return email;
    }

    public Human GetNewHuman(int experiencePoints)
    {
        var name = GenerateName();
        var mail = GenerateEmail(name);
        var hardSkills = GetRandomDictionary(experiencePoints);
        return new Human(experiencePoints, name, mail, hardSkills);
    }

    private Dictionary<string, int> GetRandomDictionary(int number)
    {
        var result = new Dictionary<string, int>();

        while (number > 0)
        {
            string randomString = _hardSkills[Random.Range(0, _hardSkills.Count)];
            int randomNumber = Random.Range(1, number + 1);

            if (result.ContainsKey(randomString))
            {
                result[randomString] += randomNumber;
            }
            else
            {
                result[randomString] = randomNumber;
            }

            number -= randomNumber;

            if (number > 0)
            {
                var remainingStrings = _hardSkills.Except(result.Keys).ToList();

                if (remainingStrings.Count > 0)
                {
                    _hardSkills = remainingStrings;
                }
                else
                {
                    _hardSkills = result.Keys.ToList();
                }
            }
        }

        return result;
    }
}
