using System.Numerics;

namespace task_03
{
    public static class Extensions
    {
        public static Vector2 Multiply(this Vector2 vector2, double mult)=>
            new Vector2((float)(vector2.X * mult),(float)(vector2.Y * mult));
    }
}