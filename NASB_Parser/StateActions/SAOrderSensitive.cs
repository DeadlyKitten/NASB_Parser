using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOrderSensitive : StateAction
    {
        public List<StateAction> Actions { get; private set; } = new List<StateAction>();

        public SAOrderSensitive()
        {
        }

        internal SAOrderSensitive(BulkSerializeReader reader) : base(reader)
        {
            Actions = reader.ReadList(r => Read(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Actions);
        }
    }
}