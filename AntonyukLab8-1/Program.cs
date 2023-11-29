using System;
using System.Collections.Generic;

// Singleton патерн для ConfigurationManager
public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private Dictionary<string, string> configSettings;

    private ConfigurationManager()
    {
        // Ініціалізація конфігураційних налаштувань
        configSettings = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    // Метод для отримання значення конфігураційного параметра
    public string GetSetting(string key)
    {
        if (configSettings.ContainsKey(key))
        {
            return configSettings[key];
        }
        else
        {
            return "Setting not found";
        }
    }

    // Метод для встановлення або оновлення конфігураційного параметра
    public void SetSetting(string key, string value)
    {
        configSettings[key] = value;
        Console.WriteLine($"Setting '{key}' updated to '{value}'");
    }

    // Метод для виведення всіх конфігураційних налаштувань
    public void PrintSettings()
    {
        Console.WriteLine("Current Configuration Settings:");
        foreach (var setting in configSettings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        while (true)
        {
            Console.WriteLine("1. Get Setting");
            Console.WriteLine("2. Set Setting");
            Console.WriteLine("3. Print Settings");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter setting key: ");
                    string getKey = Console.ReadLine();
                    Console.WriteLine($"Value for '{getKey}': {configManager.GetSetting(getKey)}");
                    break;

                case "2":
                    Console.Write("Enter setting key: ");
                    string setKey = Console.ReadLine();
                    Console.Write("Enter setting value: ");
                    string setValue = Console.ReadLine();
                    configManager.SetSetting(setKey, setValue);
                    break;

                case "3":
                    configManager.PrintSettings();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
