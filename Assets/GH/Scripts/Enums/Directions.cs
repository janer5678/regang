using System;

namespace GH.Scripts.Enums
{
    [Flags]
    public enum Directions
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 4,
        Down = 8,
    }
}
