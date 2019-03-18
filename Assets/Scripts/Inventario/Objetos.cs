public static class Objetos
{
    private static int inventario1 = -1;
    private static int inventario2 = -1;
    private static int inventario3 = -1;
    private static int inventario4 = -1;
    private static int inv1cool = 0;
    private static int inv2cool = 0;
    private static int inv3cool = 0;
    private static int inv4cool = 0;
    private static int inv1ener = 0;
    private static int inv2ener = 0;
    private static int inv3ener = 0;
    private static int inv4ener = 0;
    private static int objSelec = 0;
    private static int precioSelec = 0;

    public static int Inv4ener
    {
        get
        {
            return inv4ener;
        }
        set
        {
            inv4ener = value;
        }
    }

    public static int Inv3ener
    {
        get
        {
            return inv3ener;
        }
        set
        {
            inv3ener = value;
        }
    }

    public static int Inv2ener
    {
        get
        {
            return inv2ener;
        }
        set
        {
            inv2ener = value;
        }
    }

    public static int Inv1ener
    {
        get
        {
            return inv1ener;
        }
        set
        {
            inv1ener = value;
        }
    }

    public static int Inv4cool
    {
        get
        {
            return inv4cool;
        }
        set
        {
            inv4cool = value;
        }
    }

    public static int Inv3cool
    {
        get
        {
            return inv3cool;
        }
        set
        {
            inv3cool = value;
        }
    }

    public static int Inv2cool
    {
        get
        {
            return inv2cool;
        }
        set
        {
            inv2cool = value;
        }
    }

    public static int Inv1cool
    {
        get
        {
            return inv1cool;
        }
        set
        {
            inv1cool = value;
        }
    }

    public static int Inv1
    {
        get
        {
            return inventario1;
        }
        set
        {
            inventario1 = value;
        }
    }
    public static int Inv2
    {
        get
        {
            return inventario2;
        }
        set
        {
            inventario2 = value;
        }
    }
    public static int Inv3
    {
        get
        {
            return inventario3;
        }
        set
        {
            inventario3 = value;
        }
    }
    public static int Inv4
    {
        get
        {
            return inventario4;
        }
        set
        {
            inventario4 = value;
        }
    }

    public static int ObjSelec
    {
        get
        {
            return objSelec;
        }
        set
        {
            objSelec = value;
        }
    }

    public static int PrecioSelec
    {
        get
        {
            return precioSelec;
        }
        set
        {
            precioSelec = value;
        }
    }

    public static bool esValido(int personaje,int objeto)
    {
        switch (personaje)
        {
            case 1:
                {
                    if (objeto <= 8||objeto>=36)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
            case 2:
                {
                    if ((objeto >=9&&objeto<=17) || objeto >= 36)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
            case 3:
                {
                    if ((objeto >= 18 && objeto <= 26) || objeto >= 36)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
            case 4:
                {
                    if ((objeto >= 27 && objeto <= 35) || objeto >= 36)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
            default:
                {
                    return false;
                    break;
                }
        }
    }
}