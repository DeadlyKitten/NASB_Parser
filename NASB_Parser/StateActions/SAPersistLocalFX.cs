using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAPersistLocalFX : StateAction
    {
        public FloatSource Persist { get; set; }
        public bool MaxOut { get; set; }

        public SAPersistLocalFX()
        {
        }

        internal SAPersistLocalFX(BulkSerializeReader reader) : base(reader)
        {
            Persist = FloatSource.Read(reader);
            MaxOut = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Persist);
            writer.Write(MaxOut);
        }
    }
}
