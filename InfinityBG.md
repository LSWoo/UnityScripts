### 무한 스크롤 배경

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBG : MonoBehaviour
{
    public GameObject[] BG;
    public GameObject Player;
    int BG_Num = 0;
    float bgScale = 17.81677F;
    float NextPos = 53.4503F;
    double DesPos;

    private void Start()
    {
        //Player = Managers._data.Player;
        DesPos = 20f;
    }
    void Update()
    {
        if (Player.transform.position.x >= DesPos)
        {
            if (BG_Num == 3)
                BG_Num = 0;
            DesPos += bgScale;

            BG[BG_Num].transform.position = new Vector2(NextPos, BG[BG_Num].transform.position.y);

            NextPos += bgScale;
            BG_Num++;
        }
    }
}

```
