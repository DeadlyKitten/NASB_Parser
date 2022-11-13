using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAFindLastHorizontalInput : StateAction
    {
        public SearchType Search { get; set; }
        public StickType Stick { get; set; }
        public int ResultInScratch { get; set; }
        public int DurationFrames { get; set; }

        public SAFindLastHorizontalInput()
        {
        }

        internal SAFindLastHorizontalInput(BulkSerializeReader reader) : base(reader)
        {
            Search = (SearchType)reader.ReadInt();
            ResultInScratch = reader.ReadInt();
            if (Version >= 1)
            {
                Stick = (StickType)reader.ReadInt();
                DurationFrames = reader.ReadInt();
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            Version = 1;
            base.Write(writer);
            writer.Write(Search);
            writer.Write(ResultInScratch);
            writer.Write(Stick);
            writer.Write(DurationFrames);
        }

        public enum SearchType
        {
            None,
            NormalButtonDown,
            StrongButtonDown,
            SpecialButtonDown,
            AnyCombatButtonDown
        }

        public enum StickType
        {
            Both,
            LeftOnly,
            RightOnly
        }
    }
}