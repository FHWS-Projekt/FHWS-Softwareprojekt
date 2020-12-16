using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonParser {


    public T ReadFromJson<T>(string path) {
        string elementJson = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(elementJson);
    }

    public void WriteToJson<T>(T element, string path) {
        string elementJson = JsonUtility.ToJson(element, true);
        File.WriteAllText(path, elementJson);
    }
}