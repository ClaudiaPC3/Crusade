public static class Objetos
{

    private static int inventario1 = -1;
    private static int inventario2 = -1;
    private static int inventario3 = -1;
    private static int inventario4 = -1;
    private static int objSelec = 0;
    /**
     * Character es usado para saber que personaje fue seleccionado
     * */
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

    public static bool esValido(int personaje,int objeto)
    {
        switch (personaje)
        {
            case 0:
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
            case 1:
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
            case 2:
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
            case 3:
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