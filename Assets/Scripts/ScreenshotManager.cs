using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject ScreenPanel;
    [SerializeField] TextMeshProUGUI saveText;


    public void ScreenShot()
    {
        StartCoroutine(CaptureScreen());
    }

    public IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();

        UIPanel.SetActive(false);
        ScreenPanel.SetActive(true);
        saveText.gameObject.SetActive(true);

        yield return new WaitForEndOfFrame();

        // Take screenshot
        string path = GetPath() + "\\" + System.DateTime.Now.ToString("yy'-'MM'-'dd'-'hh'-'mm'-'ss") + ".png";
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log(path);
        saveText.text = "Saved to: " + path;

        UIPanel.SetActive(true);
        ScreenPanel.SetActive(false);
        Invoke("DeavtivateSaveText", 5);
    }

    public void OpenScreenShotFolder()
    {
        string itemPath = Application.dataPath + "/";   // explorer doesn't like front slashes
        itemPath = itemPath.Replace(@"/", @"\");
        System.Diagnostics.Process.Start("explorer.exe", "/select," + itemPath);
    }

    string GetPath()
    {
        string path = Application.dataPath;
        var parentPath = Path.GetDirectoryName(path);
        return parentPath;
    }

    void DeavtivateSaveText()
    {
        saveText.gameObject.SetActive(false);
    }
}
