
using Infision.MHCP.Proto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infision.MHCP.Entities.Response
{
    public sealed class AlarmEventMessage
    {
        public DeviceIdentifier DeviceId { get; set; } = new DeviceIdentifier();
        public DateTimeOffset OccurrenceTime { get; set; }
        public List<AlarmInfo> Alarms { get; } = new List<AlarmInfo>();

        public static AlarmEventMessage Parse(ReadOnlySpan<byte> payload)
        {
            var message = new AlarmEventMessage();
            var reader = new ProtobufReader(payload);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 2:
                        ParseHeader(reader.ReadLengthDelimited(), message);
                        break;
                    case 2 when wireType == 2:
                        message.Alarms.Add(ParseAlarm(reader.ReadLengthDelimited()));
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }
            return message;
        }

        private static void ParseHeader(ReadOnlySpan<byte> span, AlarmEventMessage message)
        {
            var headerReader = new ProtobufReader(span);
            while (!headerReader.EOF)
            {
                var (field, wireType) = headerReader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 2:
                        message.DeviceId = DeviceIdentifier.Parse(headerReader.ReadLengthDelimited());
                        break;
                    case 2 when wireType == 2:
                        message.OccurrenceTime = ParseTimestamp(headerReader.ReadLengthDelimited());
                        break;
                    default:
                        SkipUnknown(ref headerReader, wireType);
                        break;
                }
            }
        }

        private static AlarmInfo ParseAlarm(ReadOnlySpan<byte> span)
        {
            var alarm = new AlarmInfo();
            var reader = new ProtobufReader(span);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 0:
                        alarm.Id = reader.ReadVarint();
                        break;
                    case 2 when wireType == 0:
                        alarm.Level = (AlarmLevel)reader.ReadVarint();
                        break;
                    case 3 when wireType == 0:
                        alarm.State = (AlarmState)reader.ReadVarint();
                        break;
                    case 4 when wireType == 2:
                        alarm.Details.Add(ParseDetail(reader.ReadLengthDelimited()));
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }
            return alarm;
        }

        private static AlarmDetailInfo ParseDetail(ReadOnlySpan<byte> span)
        {
            var detail = new AlarmDetailInfo();
            var reader = new ProtobufReader(span);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 2:
                        var strInfo = ParseKeyIdValueStr(reader.ReadLengthDelimited());
                        detail.ParamId = strInfo.paramId;
                        detail.ValueString = strInfo.valueStr;
                        detail.ValueId = null;
                        break;
                    case 2 when wireType == 2:
                        var idInfo = ParseKeyIdValueId(reader.ReadLengthDelimited());
                        detail.ParamId = idInfo.paramId;
                        detail.ValueId = idInfo.valueId;
                        detail.ValueString = null;
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }
            return detail;
        }

        private static (uint paramId, string valueStr) ParseKeyIdValueStr(ReadOnlySpan<byte> span)
        {
            uint id = 0;
            string value = string.Empty;
            var reader = new ProtobufReader(span);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 0:
                        id = reader.ReadVarint();
                        break;
                    case 2 when wireType == 2:
                        value = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }
            return (id, value);
        }

        private static (uint paramId, uint valueId) ParseKeyIdValueId(ReadOnlySpan<byte> span)
        {
            uint id = 0;
            uint valueId = 0;
            var reader = new ProtobufReader(span);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 0:
                        id = reader.ReadVarint();
                        break;
                    case 2 when wireType == 0:
                        valueId = reader.ReadVarint();
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }
            return (id, valueId);
        }

        private static DateTimeOffset ParseTimestamp(ReadOnlySpan<byte> span)
        {
            long seconds = 0;
            int nanos = 0;
            var reader = new ProtobufReader(span);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 0:
                        seconds = (long)reader.ReadVarint();
                        break;
                    case 2 when wireType == 0:
                        nanos = (int)reader.ReadVarint();
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }

            var dto = DateTimeOffset.FromUnixTimeSeconds(seconds);
            if (nanos != 0)
            {
                dto = dto.AddTicks(nanos / 100);
            }
            return dto;
        }

        private static void SkipUnknown(ref ProtobufReader reader, int wireType)
        {
            switch (wireType)
            {
                case 0:
                    reader.ReadVarint();
                    break;
                case 1:
                    reader.ReadFixed64();
                    break;
                case 2:
                    reader.ReadLengthDelimited();
                    break;
                case 5:
                    reader.ReadFixed32();
                    break;
                default:
                    throw new NotSupportedException($"Wire type {wireType} not supported");
            }
        }
    }

    public sealed class AlarmInfo
    {
        public uint Id { get; set; }
        public AlarmLevel Level { get; set; }
        public AlarmState State { get; set; }
        public List<AlarmDetailInfo> Details { get; } = new List<AlarmDetailInfo>();
    }

    public sealed class AlarmDetailInfo
    {
        public uint? ParamId { get; set; }
        public string? ValueString { get; set; }
        public uint? ValueId { get; set; }
    }

    public enum AlarmLevel
    {
        None = 0,
        Hint = 1,
        Low = 2,
        Middle = 3,
        High = 4
    }

    public enum AlarmState
    {
        None = 0,
        Create = 1,
        Confirm = 2,
        Clear = 3
    }
}

