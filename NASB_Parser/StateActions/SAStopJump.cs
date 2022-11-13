using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStopJump : StateAction
    {
        public bool StopAll { get; set; }
        public string JumpId { get; set; }
        public string[] JumpIds { get; set; }

        public SAStopJump()
        {
        }

        internal SAStopJump(BulkSerializeReader reader) : base(reader)
        {
            StopAll = reader.ReadBool();
            JumpId = reader.ReadString();
            if (Version > 0)
            {
                JumpIds = new string[reader.ReadInt()];
                for (int i = 0; i < JumpIds.Length; i++)
                {
                    JumpIds[i] = reader.ReadString();
                }
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            Version = 1;
            base.Write(writer);
            writer.Write(StopAll);
            writer.Write(JumpId);
            writer.Write(JumpIds.Length);
            for (int i = 0; i < JumpIds.Length; i++)
            {
                writer.Write(JumpIds[i]);
            }
        }
    }
}