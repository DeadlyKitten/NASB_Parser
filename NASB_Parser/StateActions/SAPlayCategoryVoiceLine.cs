using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    [Serializable]
    public class SAPlayCategoryVoiceLine : StateAction
    {
        public string CategoryId { get; set; }
        public bool CheckAvailableLines { get; set; }

        public SAPlayCategoryVoiceLine()
        {
        }

        internal SAPlayCategoryVoiceLine(BulkSerializeReader reader) : base(reader)
        {
            CategoryId = reader.ReadString();
            if (Version > 0) CheckAvailableLines = reader.ReadInt() == 1;
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CategoryId);
            writer.Write(CheckAvailableLines ? 1 : 0);
        }
    }
}