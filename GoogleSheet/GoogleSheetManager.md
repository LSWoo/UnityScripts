
### 파일 형식
- tsv (Tab-separated values) : 탭 단위로 나누어진다.
- csv (Comma-separated values) : 콤마 단위로 나누어 진다.  

### URL
```Text
URL 은 첫번째 시트의 경우 gid 가 0 의 값을 가지지만 두번째 시트부터는 gid 가 큰값을 가진다.
시트 읽기 : "https://docs.google.com/spreadsheets/d/[ID]/export?format=tsv&gid=[시트 ID]";
```

### 읽기 범위
&range=[행:열] 을 적어주면 된다.  
"https://docs.google.com/spreadsheets/d/[ID]/export?format=tsv&gid=[시트 ID]&range=[A2:D]";  


```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager
{
    const string FunitureDataURL = "https://docs.google.com/spreadsheets/d/1vDSMODTegnx3M7vqFJDa7e9X7FTm4uds5kAyllxysuo/export?format=tsv&range=A2:E";
    const string HamsterDataURL = "https://docs.google.com/spreadsheets/d/1vDSMODTegnx3M7vqFJDa7e9X7FTm4uds5kAyllxysuo/export?format=tsv&gid=2130708142&range=A2:D";

    public IEnumerator SetFunitureData()
    {
        UnityWebRequest www = UnityWebRequest.Get(FunitureDataURL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] row = data.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;
        
        for (int i = 0; i < rowSize; i++)
        {
          string[] column = row[i].Split('\t');
          Managers._data.FunitureData.Add(new FunitureInfo(int.Parse(column[0]), column[1], int.Parse(column[2]), int.Parse(column[3]) ));
        }
    }
}
```
