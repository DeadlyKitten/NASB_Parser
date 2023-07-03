using NASB_Parser.FloatSources;
using System;

namespace NASB_Parser.Jumps
{
    [Serializable]
    public class DelayedJump : Jump
    {
        public FloatSource Height { get; set; }
        public FloatSource AutoHoldFrames { get; set; }
        public FloatSource YVelMaxOnRelease { get; set; }

        public DelayedJump()
        {
        }

        internal DelayedJump(BulkSerializeReader reader) : base(reader)
        {
            
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
        }
    }
}
