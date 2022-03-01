using System;
using System.Collections;
using System.Collections.Generic;

public static class IntUtil
{
    #region Fields

    private static Random random;

    #endregion

    #region Behaviour

    private static void Init()
    {
        if (random == null) random = new Random();
    }

    public static int Random(int min, int max)
    {
        Init();
        return random.Next(min, max);
    }

    #endregion
}
