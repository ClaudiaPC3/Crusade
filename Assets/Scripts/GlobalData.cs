public static class GlobalData
{
    /**
     * GlobalData se usa para guardar y consultar datos 
     * desde cualquier escena del juego.
     * Estos datos no se destuyen al cambiar de escena.
     * */
    private static int character = 1;
    private static bool enCurso = false;
    private static bool enPausa = false;
    private static bool enCofre = false;
    private static int monedas = 0;
    private static bool srel = false;
    private static bool crel = false;
    private static int punt1=0;
    private static int punt2=0;
    private static bool desb = false;
    private static float energ = 0;
    private static float energspe = 1f;
    private static float energlim = 100f;
    private static bool enTienda = false;
    private static bool server = false;

    public static bool Server
    {
        get
        {
            return server;
        }
        set
        {
            server = value;
        }
    }

    public static float EnergSpe
    {
        get
        {
            return energspe;
        }
        set
        {
            energspe = value;
        }
    }

    public static float EnergLim
    {
        get
        {
            return energlim;
        }
        set
        {
            energlim = value;
        }
    }

    public static float Energ
    {
        get
        {
            return energ;
        }
        set
        {
            energ = value;
        }
    }


    public static bool Desb
    {
        get
        {
            return desb;
        }
        set
        {
            desb = value;
        }
    }
    
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

    public static int Monedas
    {
        get
        {
            return monedas;
        }
        set
        {
            monedas = value;
        }
    }

    public static bool Srel
    {
        get
        {
            return srel;
        }
        set
        {
            srel = value;
        }
    }

    public static bool Crel
    {
        get
        {
            return crel;
        }
        set
        {
            crel = value;
        }
    }

    public static int Punt1
    {
        get
        {
            return punt1;
        }
        set
        {
            punt1 = value;
        }
    }

    public static int Punt2
    {
        get
        {
            return punt2;
        }
        set
        {
            punt2 = value;
        }
    }

    public static bool EnTienda
    {
        get
        {
            return enTienda;
        }
        set
        {
            enTienda = value;
        }
    }
}
