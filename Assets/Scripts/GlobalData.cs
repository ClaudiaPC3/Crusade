﻿public static class GlobalData
{
    private static int character;
    private static bool enCurso=false;

    public static int Character
    {
        get
        {
            return character;
        }
        set
        {
            character = value;
        }
    }

    public static bool EnCurso
    {
        get
        {
            return enCurso;
        }
        set
        {
            enCurso = value;
        }
    }

}
