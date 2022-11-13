using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAFindFloor : StateAction
    {
        public FloatSource SeekRange { get; set; }

        public SAFindFloor()
        {
        }

        internal SAFindFloor(BulkSerializeReader reader) : base(reader)
        {
            SeekRange = (Version > 0) ? FloatSource.Read(reader) : new FSValue(reader.ReadFloat());
        }

        public override void Write(BulkSerializeWriter writer)
        {
            Version = 1;
            base.Write(writer);
            writer.Write(SeekRange);
        }
    }
}