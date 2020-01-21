using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static string _path; // Static path to be given to StreamReader
    private StreamReader _file;
    private string _fullText;

    [SerializeField] public string path; // Serializefield that gets a path
    [SerializeField] private float _wait = 0.1f;

    private void Start()
    {
        // Assign path
        _path = path;
        _file = new StreamReader(_path, true);

        _fullText = GetFileContents();

        StartCoroutine(OutputText());
    }

    // Converts the file into separate lines and into separate chars to output
    private IEnumerator OutputText()
    {
        string currentText = "";

        for (int i = 0; i <= _fullText.Length; i++)
        {
            currentText = _fullText.Substring(0, i);

            GetComponent<Text>().text = currentText;

            yield return new WaitForSeconds(_wait);
        }
    }

    // Returns a string with all the file contents
    private string GetFileContents()
    {
        string line;
        string fullText = "";

        while ((line = _file.ReadLine()) != null)
        {
            if (line.Contains(".") || line.Contains("..."))
            {
                fullText += "\n" + line;
            }
            else
            {
                fullText += line;
            }
        }

        return fullText;
    }
}
