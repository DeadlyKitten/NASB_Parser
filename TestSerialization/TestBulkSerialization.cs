using NASB_Parser;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace TestSerialization
{
    public class TestBulkSerialization
    {
        private const int INT_COUNT = 6383;
        private const int FLOAT_COUNT = 74;
        private const int FLOAT_IDX_COUNT = 1341;
        private const int STRING_COUNT = 198;
        private const int STRING_IDX_COUNT = 815;
        private const int STATE_COUNT = 26;

        [Fact]
        public void TestDeserialize()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            Assert.Equal(INT_COUNT, ser.IntCount);
            Assert.Equal(FLOAT_COUNT, ser.FloatCount);
            Assert.Equal(FLOAT_IDX_COUNT, ser.FloatIdxCount);
            Assert.Equal(STRING_COUNT, ser.StringCount);
            Assert.Equal(STRING_IDX_COUNT, ser.StringIdxCount);
        }

        [Fact]
        public void TestDeserializeType()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            var type = new SerialMoveset(ser);
            Assert.Equal(STATE_COUNT, type.States.Count);
        }

        [Fact]
        public void TestRoundTrip()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            Assert.Equal(INT_COUNT, ser.IntCount);
            Assert.Equal(FLOAT_COUNT, ser.FloatCount);
            Assert.Equal(FLOAT_IDX_COUNT, ser.FloatIdxCount);
            Assert.Equal(STRING_COUNT, ser.StringCount);
            Assert.Equal(STRING_IDX_COUNT, ser.StringIdxCount);
            var writer = new BulkSerializeWriter();
            while (ser.NextInt < ser.IntCount)
            {
                writer.AddInt(ser.ReadInt());
            }
            while (ser.NextFloat < ser.FloatIdxCount)
            {
                writer.AddFloat(ser.ReadFloat());
            }
            while (ser.NextString < ser.StringIdxCount)
            {
                writer.AddString(ser.ReadString());
            }
            using var stream = new MemoryStream();
            using var innerS = new StreamWriter(stream);
            writer.Serialize(innerS);
            innerS.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var ser2 = new BulkSerializeReader(stream);
            Assert.Equal(INT_COUNT, ser2.IntCount);
            Assert.Equal(FLOAT_COUNT, ser2.FloatCount);
            Assert.Equal(FLOAT_IDX_COUNT, ser2.FloatIdxCount);
            Assert.Equal(STRING_COUNT, ser2.StringCount);
            Assert.Equal(STRING_IDX_COUNT, ser2.StringIdxCount);
            ser.Reset();
            while (ser.NextInt < ser.IntCount)
            {
                Assert.Equal(ser.ReadInt(), ser2.ReadInt());
            }
            while (ser.NextFloat < ser.FloatIdxCount)
            {
                Assert.Equal(ser.ReadFloat(), ser2.ReadFloat());
            }
            while (ser.NextString < ser.StringIdxCount)
            {
                Assert.Equal(ser.ReadString(), ser2.ReadString());
            }
        }

        [Fact]
        public void TestParseType()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            Assert.Equal(INT_COUNT, ser.IntCount);
            Assert.Equal(FLOAT_COUNT, ser.FloatCount);
            Assert.Equal(FLOAT_IDX_COUNT, ser.FloatIdxCount);
            Assert.Equal(STRING_COUNT, ser.StringCount);
            Assert.Equal(STRING_IDX_COUNT, ser.StringIdxCount);
            var typeInfo = new SerialMoveset(ser);
            var writer = new BulkSerializeWriter();
            typeInfo.Write(writer);
            Assert.Equal(INT_COUNT, writer.IntCount);
            Assert.Equal(FLOAT_IDX_COUNT, writer.FloatCount);
            Assert.Equal(STRING_IDX_COUNT, writer.StringCount);
            using var stream = new MemoryStream();
            using var innerS = new StreamWriter(stream);
            writer.Serialize(innerS);
            innerS.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var ser2 = new BulkSerializeReader(stream);
            Assert.Equal(INT_COUNT, ser2.IntCount);
            Assert.Equal(FLOAT_COUNT, ser2.FloatCount);
            Assert.Equal(FLOAT_IDX_COUNT, ser2.FloatIdxCount);
            Assert.Equal(STRING_COUNT, ser2.StringCount);
            Assert.Equal(STRING_IDX_COUNT, ser2.StringIdxCount);
            var typeInfo2 = new SerialMoveset(ser2);
            ser2.Reset();
            ser.Reset();
            while (ser.NextInt < ser.IntCount)
            {
                Assert.Equal(ser.ReadInt(), ser2.ReadInt());
            }
            while (ser.NextFloat < ser.FloatIdxCount)
            {
                Assert.Equal(ser.ReadFloat(), ser2.ReadFloat());
            }
            while (ser.NextString < ser.StringIdxCount)
            {
                Assert.Equal(ser.ReadString(), ser2.ReadString());
            }
            // TODO: Assert typeInfo and typeInfo2 are the same, for all members.
        }
    }
}