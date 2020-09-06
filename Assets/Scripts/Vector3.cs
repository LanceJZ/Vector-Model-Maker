using System;
using System.ComponentModel;
using System.Text;

public struct Vector3 : IEquatable<Vector3>
{
    #region Private Fields

    private static Vector3 zero = new Vector3(0f, 0f, 0f);
    private static Vector3 one = new Vector3(1f, 1f, 1f);
    private static Vector3 unitX = new Vector3(1f, 0f, 0f);
    private static Vector3 unitY = new Vector3(0f, 1f, 0f);
    private static Vector3 unitZ = new Vector3(0f, 0f, 1f);
    private static Vector3 up = new Vector3(0f, 1f, 0f);
    private static Vector3 down = new Vector3(0f, -1f, 0f);
    private static Vector3 right = new Vector3(1f, 0f, 0f);
    private static Vector3 left = new Vector3(-1f, 0f, 0f);
    private static Vector3 forward = new Vector3(0f, 0f, -1f);
    private static Vector3 backward = new Vector3(0f, 0f, 1f);

    #endregion Private Fields


    #region Public Fields

    public float X;
    public float Y;
    public float Z;

    #endregion Public Fields


    #region Properties

    public static Vector3 Zero
    {
        get { return zero; }
    }

    public static Vector3 One
    {
        get { return one; }
    }

    public static Vector3 UnitX
    {
        get { return unitX; }
    }

    public static Vector3 UnitY
    {
        get { return unitY; }
    }

    public static Vector3 UnitZ
    {
        get { return unitZ; }
    }

    public static Vector3 Up
    {
        get { return up; }
    }

    public static Vector3 Down
    {
        get { return down; }
    }

    public static Vector3 Right
    {
        get { return right; }
    }

    public static Vector3 Left
    {
        get { return left; }
    }

    public static Vector3 Forward
    {
        get { return forward; }
    }

    public static Vector3 Backward
    {
        get { return backward; }
    }

    #endregion Properties


    #region Constructors

    public Vector3(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }


    public Vector3(float value)
    {
        this.X = value;
        this.Y = value;
        this.Z = value;
    }
    #endregion Constructors


    #region Public Methods

    public static Vector3 Add(Vector3 value1, Vector3 value2)
    {
        value1.X += value2.X;
        value1.Y += value2.Y;
        value1.Z += value2.Z;
        return value1;
    }

    public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
    {
        result.X = value1.X + value2.X;
        result.Y = value1.Y + value2.Y;
        result.Z = value1.Z + value2.Z;
    }

    public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
    {
        Cross(ref vector1, ref vector2, out vector1);
        return vector1;
    }

    public static void Cross(ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
    {
        result = new Vector3(vector1.Y * vector2.Z - vector2.Y * vector1.Z,
                                -(vector1.X * vector2.Z - vector2.X * vector1.Z),
                                vector1.X * vector2.Y - vector2.X * vector1.Y);
    }

    public static float Distance(Vector3 vector1, Vector3 vector2)
    {
        float result;
        DistanceSquared(ref vector1, ref vector2, out result);
        return (float)Math.Sqrt(result);
    }

    public static void Distance(ref Vector3 value1, ref Vector3 value2, out float result)
    {
        DistanceSquared(ref value1, ref value2, out result);
        result = (float)Math.Sqrt(result);
    }

    public static float DistanceSquared(Vector3 value1, Vector3 value2)
    {
        float result;
        DistanceSquared(ref value1, ref value2, out result);
        return result;
    }

    public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out float result)
    {
        result = (value1.X - value2.X) * (value1.X - value2.X) +
                    (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                    (value1.Z - value2.Z) * (value1.Z - value2.Z);
    }

    public static Vector3 Divide(Vector3 value1, Vector3 value2)
    {
        value1.X /= value2.X;
        value1.Y /= value2.Y;
        value1.Z /= value2.Z;
        return value1;
    }

    public static Vector3 Divide(Vector3 value1, float value2)
    {
        float factor = 1 / value2;
        value1.X *= factor;
        value1.Y *= factor;
        value1.Z *= factor;
        return value1;
    }

    public static void Divide(ref Vector3 value1, float divisor, out Vector3 result)
    {
        float factor = 1 / divisor;
        result.X = value1.X * factor;
        result.Y = value1.Y * factor;
        result.Z = value1.Z * factor;
    }

    public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
    {
        result.X = value1.X / value2.X;
        result.Y = value1.Y / value2.Y;
        result.Z = value1.Z / value2.Z;
    }

    public static float Dot(Vector3 vector1, Vector3 vector2)
    {
        return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
    }

    public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out float result)
    {
        result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
    }

    public override bool Equals(object obj)
    {
        return (obj is Vector3) ? this == (Vector3)obj : false;
    }

    public bool Equals(Vector3 other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return (int)(this.X + this.Y + this.Z);
    }

    public float Length()
    {
        float result;
        DistanceSquared(ref this, ref zero, out result);
        return (float)Math.Sqrt(result);
    }

    public float LengthSquared()
    {
        float result;
        DistanceSquared(ref this, ref zero, out result);
        return result;
    }


    public static Vector3 Multiply(Vector3 value1, Vector3 value2)
    {
        value1.X *= value2.X;
        value1.Y *= value2.Y;
        value1.Z *= value2.Z;
        return value1;
    }

    public static Vector3 Multiply(Vector3 value1, float scaleFactor)
    {
        value1.X *= scaleFactor;
        value1.Y *= scaleFactor;
        value1.Z *= scaleFactor;
        return value1;
    }

    public static void Multiply(ref Vector3 value1, float scaleFactor, out Vector3 result)
    {
        result.X = value1.X * scaleFactor;
        result.Y = value1.Y * scaleFactor;
        result.Z = value1.Z * scaleFactor;
    }

    public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
    {
        result.X = value1.X * value2.X;
        result.Y = value1.Y * value2.Y;
        result.Z = value1.Z * value2.Z;
    }

    public static Vector3 Negate(Vector3 value)
    {
        value = new Vector3(-value.X, -value.Y, -value.Z);
        return value;
    }

    public static void Negate(ref Vector3 value, out Vector3 result)
    {
        result = new Vector3(-value.X, -value.Y, -value.Z);
    }

    public void Normalize()
    {
        Normalize(ref this, out this);
    }

    public static Vector3 Normalize(Vector3 vector)
    {
        Normalize(ref vector, out vector);
        return vector;
    }

    public static void Normalize(ref Vector3 value, out Vector3 result)
    {
        float factor;
        Distance(ref value, ref zero, out factor);
        factor = 1f / factor;
        result.X = value.X * factor;
        result.Y = value.Y * factor;
        result.Z = value.Z * factor;
    }

    public static Vector3 Reflect(Vector3 vector, Vector3 normal)
    {
        throw new NotImplementedException();
    }

    public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
    {
        throw new NotImplementedException();
    }

    public static Vector3 Subtract(Vector3 value1, Vector3 value2)
    {
        value1.X -= value2.X;
        value1.Y -= value2.Y;
        value1.Z -= value2.Z;
        return value1;
    }

    public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
    {
        result.X = value1.X - value2.X;
        result.Y = value1.Y - value2.Y;
        result.Z = value1.Z - value2.Z;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(32);
        sb.Append("{X:");
        sb.Append(this.X);
        sb.Append(" Y:");
        sb.Append(this.Y);
        sb.Append(" Z:");
        sb.Append(this.Z);
        sb.Append("}");
        return sb.ToString();
    }
    #endregion Public methods


    #region Operators

    public static bool operator ==(Vector3 value1, Vector3 value2)
    {
        return value1.X == value2.X
            && value1.Y == value2.Y
            && value1.Z == value2.Z;
    }

    public static bool operator !=(Vector3 value1, Vector3 value2)
    {
        return !(value1 == value2);
    }

    public static Vector3 operator +(Vector3 value1, Vector3 value2)
    {
        value1.X += value2.X;
        value1.Y += value2.Y;
        value1.Z += value2.Z;
        return value1;
    }

    public static Vector3 operator -(Vector3 value)
    {
        value = new Vector3(-value.X, -value.Y, -value.Z);
        return value;
    }

    public static Vector3 operator -(Vector3 value1, Vector3 value2)
    {
        value1.X -= value2.X;
        value1.Y -= value2.Y;
        value1.Z -= value2.Z;
        return value1;
    }

    public static Vector3 operator *(Vector3 value1, Vector3 value2)
    {
        value1.X *= value2.X;
        value1.Y *= value2.Y;
        value1.Z *= value2.Z;
        return value1;
    }

    public static Vector3 operator *(Vector3 value, float scaleFactor)
    {
        value.X *= scaleFactor;
        value.Y *= scaleFactor;
        value.Z *= scaleFactor;
        return value;
    }

    public static Vector3 operator *(float scaleFactor, Vector3 value)
    {
        value.X *= scaleFactor;
        value.Y *= scaleFactor;
        value.Z *= scaleFactor;
        return value;
    }

    public static Vector3 operator /(Vector3 value1, Vector3 value2)
    {
        value1.X /= value2.X;
        value1.Y /= value2.Y;
        value1.Z /= value2.Z;
        return value1;
    }

    public static Vector3 operator /(Vector3 value, float divider)
    {
        float factor = 1 / divider;
        value.X *= factor;
        value.Y *= factor;
        value.Z *= factor;
        return value;
    }

    #endregion
}