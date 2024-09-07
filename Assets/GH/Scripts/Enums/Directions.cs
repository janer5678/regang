using System;

namespace GH.Scripts.Enums
{
    [Flags]
    enum Directions
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 4,
        Down = 8,
    }
}
