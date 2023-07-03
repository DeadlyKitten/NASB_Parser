using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
	[Serializable]
    public class SAPlayRootAnim : StateAction
    {
        public string Anim { get; set; }
        public FloatSource Rate { get; set; }
        public bool SetRateOnly { get; set; }
        public FloatSource Frame { get; set; }
        public bool SetFrame { get; set; }

        public SAPlayRootAnim()
        {
        }

        internal SAPlayRootAnim(BulkSerializeReader reader) : base(reader)
        {
            Anim = reader.ReadString();
            Rate = Version > 0 ? FloatSource.Read(reader) : new FSValue(reader.ReadFloat());
            SetRateOnly = reader.ReadBool();
            Frame = Version > 0 ? FloatSource.Read(reader) : new FSValue(reader.ReadFloat());
            SetFrame = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            Version = 1;
            base.Write(writer);
            writer.Write(Anim);
            writer.Write(Rate);
            writer.Write(SetRateOnly);
            writer.Write(Frame);
            writer.Write(SetFrame);
        }
    }
}
