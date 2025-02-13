using Newtonsoft.Json.Linq;

public static class JSONHelper
{
    public class JSONCheck
    {
        public string JsonPath { get; set; }
        public object MatchValue { get; set; }

        public JSONCheck(string jsonPath, object matchValue)
        {
            JsonPath = jsonPath;
            MatchValue = matchValue;
        }
    }

    public static bool IsMatch(string json, string jsonPath, object matchValue)
    {
        try
        {
            // Parse the JSON string into a JToken (can be either JObject or JArray)
            JToken jsonToken = JToken.Parse(json);

            // Select the value at the specified JSONPath
            JToken selectedValue = jsonToken.SelectToken(jsonPath);

            // If path doesn't exist or value is null, return false
            if (selectedValue == null)
                return false;

            // Convert the selected value to match the type of matchValue
            var convertedValue = selectedValue.ToObject(matchValue.GetType());

            // Compare the values
            return convertedValue.Equals(matchValue);
        }
        catch (Exception)
        {
            // Return false in case of any parsing errors
            return false;
        }
    }

    public static bool IsMatches(string json, IEnumerable<JSONCheck> checks)
    {
        try
        {
            // Parse JSON once for all checks
            JToken jsonToken = JToken.Parse(json);

            // All checks must pass for the result to be true
            foreach (var check in checks)
            {
                JToken selectedValue = jsonToken.SelectToken(check.JsonPath);

                // If any check fails, return false immediately
                if (selectedValue == null)
                    return false;

                var convertedValue = selectedValue.ToObject(check.MatchValue.GetType());
                if (!convertedValue.Equals(check.MatchValue))
                    return false;
            }

            // All checks passed
            return true;
        }
        catch (Exception)
        {
            // Return false in case of any parsing errors
            return false;
        }
    }
}