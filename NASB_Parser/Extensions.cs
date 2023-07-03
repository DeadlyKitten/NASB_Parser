using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public static class Extensions
    {
        public static Vector3 ReadVector3(this BulkSerializeReader reader, bool useFloatSource = false)
        {
            if (useFloatSource)
            {
                var x = new FSValue(reader).Value;
                var y = new FSValue(reader).Value;
                var z = new FSValue(reader).Value;
                return new Vector3(x, y, z);
            }
            else return new Vector3(reader);
        }

        public static void Write(this BulkSerializeWriter writer, Vector3 val)
        {
            writer.Write(new FSValue(val.x));
            writer.Write(new FSValue(val.y));
            writer.Write(new FSValue(val.z));
        }

        public static void Write<T>(this BulkSerializeWriter writer, T t) where T : Enum
        {
            writer.AddInt((int)(object)t);
        }
    }
}