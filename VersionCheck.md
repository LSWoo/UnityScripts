## 업로드된 앱과 웹서버의 빌드 버전을 비교하는 스크립트
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class VersionCheck : MonoBehaviour
{
    public string URL = ""; // 버전체크를 위한 URL
    public string MarketURL = "https://play.google.com/store/apps/details?id=com.DefaultCompany.MonsterMergy";
    public string CurVersion; // 현재 빌드버전
    string latsetVersion; // 최신버전
    public GameObject VersionCheckPanel; // 버전확인 UI
    public Text VersionText;

    void Start()
    {
        CurVersion = Application.version;
        VersionText.text = CurVersion;
        StartCoroutine(LoadTxtData(URL));
    }

    public void Check()
    {
        if (CurVersion != latsetVersion)
        {
            VersionCheckPanel.SetActive(true);
        }
        else
        {
            VersionCheckPanel.SetActive(false);
        }
        Debug.Log("Current Version" + CurVersion + "Lastest Version" + latsetVersion);
    }


    IEnumerator LoadTxtData(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest(); // 페이지 요청

        if (www.isNetworkError)
        {
            Debug.Log("error get page");
        }
        else
        {
            latsetVersion = www.downloadHandler.text; // 웹에 입력된 최신버전
        }
        Check();
    }

    public void OpenURL() // 스토어 열기
    {
        Application.OpenURL(MarketURL);
    }
}

```
