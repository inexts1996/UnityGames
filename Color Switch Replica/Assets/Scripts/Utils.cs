using System;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Utils
{
    private static PlayerColorEnum GetRandomColorEnum()
    {
        var randomColorEnum = (PlayerColorEnum) Random.Range(0, 4);

        return randomColorEnum;
    }

    public static Color GetRandomColor()
    {
        
        return GetColorWith(GetRandomColorEnum);
    }

    public static Color GetColorWith(Func<PlayerColorEnum> func)
    {
        PlayerColorEnum cEnum = func();
        if (cEnum == PlayerColorEnum.Cyan) return Color.cyan;

        if (cEnum == PlayerColorEnum.Yellow) return Color.yellow;

        if (cEnum == PlayerColorEnum.Magenta) return Color.magenta;

        if (cEnum == PlayerColorEnum.Pink) return Color.grey;

        return Color.white;
    }
}