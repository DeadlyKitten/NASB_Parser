using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStopVoiceLines : StateAction
    {
        public string CategoryId { get; set; }

        public SAStopVoiceLines()
        {
        }

        internal SAStopVoiceLines(BulkSerializeReader reader) : base(reader)
        {
            CategoryId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CategoryId);
        }
    }
}
