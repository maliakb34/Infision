using System.Collections.Generic;

namespace Infision.MHCP
{
    public static class MhcpConstants
    {
        // Categories
        public const int CATEGORY_PROTOCOL = 1;
        public const int CATEGORY_REQUEST_RESPONSE = 2;

        // Requests
        public const int REQ_HEART = 1;
        public const int REQ_HEART_FREQ_SET = 257;
        public const int REQ_DEVICE_INFO = 258;
        public const int REQ_STATION_INFO = 4096;
        public const int REQ_DEPARTMENT_BED_LIST = 4097;
        public const int REQ_PATIENT_INFO = 4098;
        public const int REQ_ADMIT_PATIENT = 4099;
        public const int REQ_UPDATE_PATIENT = 4100;
        public const int REQ_PERIODIC_INFUSION_INTERVAL = 4101;
        public const int REQ_ADT_SWITCH = 4102;
        public const int REQ_INFUSION_INFO = 4103;
        public const int DOCTOR_ORDER_INFO = 4104;
        public const int DOCTOR_ORDER_CANCEL = 4105;
        public const int DOCTOR_ORDER_TERMINATE = 4114;
        public const int REQ_INFORM_DEVICE_OFFLINE = 263;
        public const int REQ_ALARM_INFO = 4113;
        public const int REQ_TIME_ZONE = 264;

        // Events
        public const int MESSAGE_PUMP_REAL_DATA = 4352;
        public const int EVENT_PATIENT_ADT = 4353;
        public const int EVENT_DEPARTMENT_BED_SWITCH = 4354;
        public const int EVENT_INFUSION_NON_START = 4355;
        public const int EVENT_INFUSION_START = 4356;
        public const int EVENT_INFUSION_COMPLETE = 4357;
        public const int EVENT_INFUSION_STOP = 4358;
        public const int EVENT_INFUSION_TITRATION = 4359;
        public const int EVENT_INFUSION_CYCLE = 4360;
        public const int EVENT_ALARM = 4362;
        public const int EVENT_STATION_UPDATE = 4364;
        public const int EVENT_DEVICE_SHUTDOWN = 4365;
        public const int EVENT_DEVICE_AUDIO_CALL = 4367;
        public const int EVENT_DEVICE_STANDBY = 4368;
        public const int EVENT_QUERY_LOG_DATA = 4609;
        public const int EVENT_ACQUIRE_LOG_RANGE_DATA = 4610;
        public const int EVENT_LOG_DATA_UPLOAD = 4611;
        public const int EVENT_ACCUMULATION_CLEARING = 4612;
        public const int EVENT_PCA_CONTROL_PRESS = 4115;

        // Optional: a place to register local handlers mirroring Java's eventServiceMap
        public static readonly Dictionary<int, Delegate> Handlers = new();
    }
}

