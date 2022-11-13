using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAPlayVoiceLine : StateAction
    {
        public string LineId { get; set; }

        public SAPlayVoiceLine()
        {
        }

        internal SAPlayVoiceLine(BulkSerializeReader reader) : base(reader)
        {
            LineId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(LineId);
        }
    }
}
