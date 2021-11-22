# Slots
**일반 스핀**
**터보 스핀**
```c#
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
