using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
    public class AirDashJump : Jump
    {
        public Ease EaseSpeed { get; set; }
        public FloatSource XDir { get; set; }
        public FloatSource YDir { get; set; }
        public FloatSource SpeedStart { get; set; }
        public FloatSource SpeedEnd { get; set; }
        public FloatSource SpeedUpMult { get; set; }
        public FloatSource SpeedDownMult { get; set; }
        public FloatSource Frames { get; set; }
        public FloatSource RedirectFrames { get; set; }

        public AirDashJump()
        {
        }

        internal AirDashJump(BulkSerializeReader reader) : base(reader)
        {
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
        }
    }
}