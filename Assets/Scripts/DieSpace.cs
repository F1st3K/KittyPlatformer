using System;

public class DieSpace : Obstacle
{
    public DieSpace()
    {
        base.damage = Int32.MaxValue;
    }
}