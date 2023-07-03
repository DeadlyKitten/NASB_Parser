using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAInputAction : StateAction
    {
        public FloatSource Frames { get; set; }
        public string Id { get; set; }
        public InputTrigger Trigger { get; set; }

        public SAInputAction()
        {
        }

        internal SAInputAction(BulkSerializeReader reader) : base(reader)
        {
            Frames = (Version > 0) ? FloatSource.Read(reader) : new FSValue(reader.ReadFloat());
            Id = reader.ReadString();
            Trigger = new InputTrigger(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            Version = 1;
            base.Write(writer);
            writer.Write(Frames);
            writer.Write(Id);
            writer.Write(Trigger);
        }
    }
}
