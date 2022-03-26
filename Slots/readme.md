# Slots
```C#
    IEnumerator LineSpin(GameObject[] _slots, int _spinCount, bool _lastLine)
    {
        for (int i = 0; i < _spinCount * 5; i++)
        {
            for (int x = 0; x < _slots.Length; x++)
            {
                _slots[x].transform.localPosition -= movePos;
            }
            yield return new WaitForSeconds(spinSpeed);
        }
        if (_lastLine)
            isSpin = false;
    }
```
**일반 스핀**  
```C#
    IEnumerator SpinSlot()
    {
       if (!isSpin && !isAuto)
       {
           isSpin = true;

           if (!isTurbo)
           {
               StartCoroutine(LineSpin(Lines_1, 4, false));
               StartCoroutine(LineSpin(Lines_2, 8, false));
               StartCoroutine(LineSpin(Lines_3, 12, false));
               StartCoroutine(LineSpin(Lines_4, 16, false));
               StartCoroutine(LineSpin(Lines_5, 20, true));
           }
           yield return null;
       }
    }
```
**터보 스핀**
```c#
    if (isTurbo && !isSpin)
    {

        int SpinCount = UnityEngine.Random.Range(7, 8);
        
        for (int i = 0; i < SpinCount * 4; i++)
        {
            isSpin = true;
            for (int j = 0; j < Slots.Length; j++)
            {
                Slots[j].transform.localPosition -= movePos;
            }
            yield return new WaitForSeconds(spinSpeed);
        }
            isSpin = false;
    }
```

