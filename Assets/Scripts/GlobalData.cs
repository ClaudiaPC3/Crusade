public static class GlobalData
{
    private static int character=1;
    private static bool enCurso=false;
    private static bool enPausa = false;
    private static bool enCofre = false;

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

    public static bool EnPausa
    {
        get
        {
            return enPausa;
        }
        set
        {
            enPausa = value;
        }
    }

    public static bool EnCofre
    {
        get
        {
            return enCofre;
        }
        set
        {
            enCofre = value;
        }
    }

}
