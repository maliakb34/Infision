Payload Builder (C#)

Overview

- MHCP patient update builder that mirrors MhcpProtocol.composePatient (header + CRC16 + protobuf payload).
- Schema-driven binary builder for other fixed-layout device packets.
- Shared utilities for protobuf-lite writing, byte ordering, and CRC16-CCITT.

Project Layout

- PayloadBuilder/Builders/MhcpPayloadBuilder.cs: Builds MHCP protocol frames (sync, CRC, header, patient info).
- PayloadBuilder/Builders/BinaryPayloadBuilder.cs: Builds bytes from a schema and value map.
- PayloadBuilder/Builders/Schema.cs: Field and schema definitions.
- PayloadBuilder/Models/Patient.cs, Models/PatientEnums.cs: Patient model and supporting enums.
- PayloadBuilder/Util/ProtoWriter.cs, Util/Crc16.cs, Util/ByteWriter.cs: Low-level helpers.
- PayloadBuilder/Examples/Program.cs: Minimal MHCP usage example.

Quick Start (MHCP Patient Update)

1. Populate a Patient with the fields required by the device (see field map below).
2. Instantiate var builder = new MhcpPayloadBuilder().
3. Call builder.BuildPatientUpdate(patient) to get the final frame bytes.
4. Write the returned bytes directly to the TCP socket (IP/TCP headers are added by the OS).

Field map (protobuf PatientInfo from the reference implementation):
- 1 id string (patient entity id, 32-char GUID in the reference capture).
- 2 departmentName string.
- 3 bedNo string.
- 4 pid string (patient identifier shown on the pump UI).
- 5 visitId string.
- 6 lastName string.
- 7 firstName string.
- 8 gender enum (Gender.Unknown/Male/Female -> 0/1/2).
- 9 age int32.
- 10 ageUnit enum (AgeUnit.Unknown/Years/Weeks -> 0/1/2).
- 11 height float32 centimetres (rounded to 1 decimal place).
- 12 weight float32 kilograms (rounded to 2 decimals).
- 13 bloodType enum (BloodType.Unknown/A/B/AB/O/NA -> 0-5).
- 14 physician string (optional).
- 15 diagnosis string (optional).
- 16 admitDate fixed64 = Unix epoch milliseconds.

Header & Framing
- Sync bytes: 0xFA 0x05.
- CRC16: CCITT-FALSE over [totalLength|headerLength|header|payload], little-endian, polynomial 0x1021, init 0xFFFF.
- totalLength = payloadLen + headerLen + 8 (matches the Java implementation).
- Header proto fields: messageId (4100 for update), categoryId (2), sequenceNumber (auto increment, wraps at 65535), routeId (0), requestResponse (1=Request).

Quick Start (Binary Builder)

1. Define a MessageSchema with ordered FieldSpec entries.
2. Optional IsLengthOfMessage field auto-patches the total length.
3. Optional IsCrc16 field appends CRC16-CCITT using schema settings.
4. Supply a dictionary of values and call BinaryPayloadBuilder.Build.

Notes

- MhcpPayloadBuilder rounds height/weight to mirror DataUtil.resetAccuracy in the Java reference.
- AdmitDateUtc is converted to Unix milliseconds (same as DateUtil.utcStrToLocalTime).
- BuildPatientUpdate returns the complete frame; no extra wrapper bytes are required.
- The binary builder and utilities remain available for other protocol payloads.
