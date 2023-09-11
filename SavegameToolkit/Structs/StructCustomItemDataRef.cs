﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SavegameToolkit.Arrays;
using SavegameToolkit.Types;

namespace SavegameToolkit.Structs {

    [JsonObject(MemberSerialization.OptIn)]
    public class StructCustomItemDataRef : StructBase {

        [JsonProperty(Order = 0)]
        public short Unknown0 { get; private set; }
        [JsonProperty(Order = 1)]
        public long Position { get; private set; }
        [JsonProperty(Order = 2)]
        public ObjectReference[] ObjectRefs { get; private set; }
        [JsonProperty(Order = 3)]
        public ObjectReference[] ClassRefs { get; private set; }

        public override void Init(ArkArchive archive)
        {
            // The first unknown field may be two fields - perhaps format version and archive index
            Unknown0 = archive.ReadShort();
            Position = archive.ReadLong();
            ObjectRefs = new ObjectReference[archive.ReadInt()];
            for (int index = 0; index < ObjectRefs.Length; index++)
            {
                ObjectRefs[index] = new ObjectReference(archive, 8);
            }
            ClassRefs = new ObjectReference[archive.ReadInt()];
            for (int index = 0; index < ClassRefs.Length; index++)
            {
                ClassRefs[index] = new ObjectReference(archive, 8);
            }
        }

        public override void Init(JObject node)
        {
            throw new NotImplementedException("JSON import of StructCustomItemDataRef has not been implemented");
        }

        public override void WriteJson(JsonTextWriter generator, WritingOptions writingOptions)
        {
            throw new NotImplementedException("JSON export of StructCustomItemDataRef has not been implemented");
        }

        public override void WriteBinary(ArkArchive archive)
        {
            throw new NotImplementedException("Binary export of StructCustomItemDataRef has not been implemented");
        }

        public override int Size(NameSizeCalculator nameSizer)
        {
            return sizeof(short) + sizeof(long) + sizeof(int) * 2 + ObjectRefs.Length * 8 + ClassRefs.Length * 8;
        }
    }

}
