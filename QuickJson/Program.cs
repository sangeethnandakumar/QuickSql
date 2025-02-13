// Example with JSON object root
string jsonObject = @"{
            'name': 'John Doe',
            'age': 30,
            'address': {
                'street': '123 Main St',
                'city': 'New York',
                'zipCode': '10001'
            },
            'hobbies': ['reading', 'gaming', 'swimming']
        }";

// Example with JSON array root
string jsonArray = @"[
            {
                'id': 1,
                'name': 'John Doe',
                'department': 'IT'
            },
            {
                'id': 2,
                'name': 'Jane Smith',
                'department': 'HR'
            }
        ]";

// Testing single checks
bool singleCheck = JSONHelper.IsMatch(jsonObject, "$.name", "John Doe");
Console.WriteLine($"Single check result: {singleCheck}"); // True



// Testing multiple checks for object root
Console.WriteLine("\nTesting Multiple Checks (Object Root):");
bool objectResult = JSONHelper.IsMatches(jsonObject, new List<JSONHelper.JSONCheck>
        {
            new JSONHelper.JSONCheck("$.name", "John Doe"),
            new JSONHelper.JSONCheck("$.age", 30),
            new JSONHelper.JSONCheck("$.address.city", "New York"),
            new JSONHelper.JSONCheck("$.hobbies[0]", "reading")
        });
Console.WriteLine($"All object checks pass: {objectResult}"); // True



// Testing multiple checks for array root
Console.WriteLine("\nTesting Multiple Checks (Array Root):");
bool arrayResult = JSONHelper.IsMatches(jsonArray, new List<JSONHelper.JSONCheck>
        {
            new JSONHelper.JSONCheck("$[0].name", "John Doe"),
            new JSONHelper.JSONCheck("$[0].department", "IT"),
            new JSONHelper.JSONCheck("$[1].name", "Jane Smith")
        });
Console.WriteLine($"All array checks pass: {arrayResult}"); // True




// Testing with failing checks
Console.WriteLine("\nTesting Failing Checks:");
bool failingResult = JSONHelper.IsMatches(jsonObject, new List<JSONHelper.JSONCheck>
        {
            new JSONHelper.JSONCheck("$.name", "John Doe"),
            new JSONHelper.JSONCheck("$.age", 31),  // This will fail
            new JSONHelper.JSONCheck("$.address.city", "New York")
        });
Console.WriteLine($"All failing checks pass: {failingResult}"); // False