using System;

namespace velocity.Extn
{
    public static class TypeHelper
    {
        public static bool IsNumeric(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.UInt32:
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool Defined(Object obj)
        {
            if (IsNumeric(obj.GetType()))
            {

                if ((int)obj == 0)
                    return false;
                else
                    return true;
            }
            return false;

        }

    }
}
