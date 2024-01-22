using System.Reflection;
using System.Text.Json;
using Kingmaker.Blueprints.JsonSystem;

var asm = typeof(TypeIdAttribute).Assembly;

Dictionary<string, string> typeDict = new();

foreach (Type classType in asm.GetTypes().Where(t => t.IsClass))
{
    TypeIdAttribute? typeid = classType.GetCustomAttribute(typeof(TypeIdAttribute)) as TypeIdAttribute;
    if (typeid == null) 
        continue;

    string guid = typeid.GuidString;
    string typeFullName = classType.FullName!;

    Console.WriteLine(typeFullName + ":" + guid);
    typeDict[guid] = typeFullName;
}

string json = JsonSerializer.Serialize(typeDict, new JsonSerializerOptions() { WriteIndented = true });
File.WriteAllText("../../../../typeguid.json", json);
