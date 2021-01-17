using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonParser {


    public T ReadFromJson<T>(string path) {
        string elementJson = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(elementJson);
    }

    public void WriteToJson<T>(T element, string path) {
        string elementJson = JsonUtility.ToJson(element, true);
        File.WriteAllText(path, elementJson);
    }

    public T ReadFromJsonOS<T>(string path) {
        T data = Activator.CreateInstance<T>();

        try {
            string dataAsJson = string.Empty;
            if (Application.platform == RuntimePlatform.WindowsEditor) {
                dataAsJson = File.ReadAllText(path);
            }
            if (Application.platform == RuntimePlatform.Android) {
#pragma warning disable 0618
                WWW reader = new WWW(path);
                while (!reader.isDone) { }

                dataAsJson = reader.text;
#pragma warning restore 0618
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                dataAsJson = File.ReadAllText(path);
            }
            data = JsonUtility.FromJson<T>(dataAsJson);

        } catch (FileNotFoundException) {
            Debug.Log("QuizData not found at: \n" + path);
        }

        return data;
    }
}