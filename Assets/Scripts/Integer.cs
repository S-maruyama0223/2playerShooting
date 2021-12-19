using System;

public class Integer
{
    private int integer;

    public Integer(int integer)
    {
        this.integer = integer;
    }

    public int getInteger()
    {
        return this.integer;
    }

    public static implicit operator int(Integer v)
    {
        throw new NotImplementedException();
    }
}
