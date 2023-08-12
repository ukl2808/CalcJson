using Newtonsoft.Json;

public class Calculator
{
    private List<string> history = new List<string>();
    private string jsonFilePath = "history.json"; // Путь к JSON файлу

    public double Add(double a, double b)
    {
        double result = a + b;
        string operation = $"{a} + {b} = {result}";
        history.Add(operation);
        SaveHistoryToJson();
        return result;
    }

    public double Subtract(double a, double b)
    {
        double result = a - b;
        string operation = $"{a} - {b} = {result}";
        history.Add(operation);
        SaveHistoryToJson();
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        string operation = $"{a} * {b} = {result}";
        history.Add(operation);
        SaveHistoryToJson();
        return result;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Деление на ноль недопустимо.");
        }

        double result = a / b;
        string operation = $"{a} / {b} = {result}";
        history.Add(operation);
        SaveHistoryToJson();
        return result;
    }

    public List<string> LoadHistoryFromJson()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            history = JsonConvert.DeserializeObject<List<string>>(json);
        }
        return history;
    }

    private void SaveHistoryToJson()
    {
        string json = JsonConvert.SerializeObject(history, Formatting.Indented);
        File.WriteAllText(jsonFilePath, json);
    }
}
