using BlazorResearchApp.Client.Model;
using System.Globalization;
using System.Text;

public class CsvService
{
    private const char delimiter = ',';

    public async Task<List<Person>> ReadCsvAsync(string content)
    {
        var people = new List<Person>();

        using (var reader = new StringReader(content))
        {
            // Skip header
            await reader.ReadLineAsync();

            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = ParseCsvLine(line);

                if (values.Count == 28)
                {
                    var person = new Person
                    {
                        Id = ParseInt(values[0]),
                        Username = values[1],
                        FirstName = values[2],
                        LastName = values[3],
                        Email = values[4],
                        PhoneNumber = values[5],
                        Country = values[6],
                        State = values[7],
                        City = values[8],
                        PostalCode = values[9],
                        StreetAddress = values[10],
                        Password = values[11],
                        SecurityQuestion1 = values[12],
                        SecurityAnswer1 = values[13],
                        SecurityQuestion2 = values[14],
                        SecurityAnswer2 = values[15],
                        DeviceType = values[16],
                        DeviceBrand = values[17],
                        DeviceModel = values[18],
                        DeviceOs = values[19],
                        LastLogin = ParseDate(values[20]),
                        AccountCreated = ParseDate(values[21]),
                        AccountStatus = values[22],
                        TwoFactorEnabled = ParseBool(values[23]),
                        LastIpAddress = values[24],
                        LoginAttempts = ParseInt(values[25]),
                        AccountLocked = ParseBool(values[26]),
                        PasswordLastChanged = ParseDate(values[27]),
                    };
                    people.Add(person);

                }
                else
                {
                    Console.WriteLine($"Skipping line due to incorrect field count: {line}");
                }
            }
        }
        return people;
    }

    private List<string> ParseCsvLine(string line)
    {
        var values = new List<string>();
        var currentField = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '"')
            {
                if (inQuotes && i < line.Length - 1 && line[i + 1] == '"')
                {
                    currentField.Append('"');
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
                continue;
            }

            if (c == delimiter && !inQuotes)
            {
                values.Add(currentField.ToString());
                currentField.Clear();
            }
            else
            {
                currentField.Append(c);
            }
        }

        values.Add(currentField.ToString());

        return values;
    }


    private DateTime ParseDate(string dateString)
    {
        DateTime dateTime;
        if (DateTime.TryParseExact(dateString, new string[] { "MM/dd/yyyy", "M/dd/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
        {
            return dateTime;
        }
        else
        {
            return DateTime.MinValue;
        }
    }

    private bool ParseBool(string boolString)
    {
        bool boolValue;
        return bool.TryParse(boolString, out boolValue) ? boolValue : false;
    }

    private int ParseInt(string intString)
    {
        int intValue;
        return int.TryParse(intString, out intValue) ? intValue : 0;
    }
}
