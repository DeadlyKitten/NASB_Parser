using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAFindFloor : StateAction
    {
        public FloatSource Range { get; set; }

        public SAFindFloor()
        { }

        internal SAFindFloor(BulkSerializeReader reader) : base(reader)
        {
            Range = (Version > 0) ? FloatSource.Read(reader) : new FSValue(reader.ReadFloat());
        }

        public override void Write(BulkSerializeWriter writer)
        {
            Version = 1;
            base.Write(writer);
            writer.Write(Range);
        }
    }
}
