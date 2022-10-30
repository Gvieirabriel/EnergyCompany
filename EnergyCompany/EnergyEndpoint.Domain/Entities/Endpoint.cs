using EnergyCompany.Domain.Enums;

namespace EnergyCompany.Domain.Entities
{
    public class Endpoint
    {
        public Endpoint(string serialNumber, int meterModelId, int meterNumber, string firmwareVersion, int switchState)
        {
            SerialNumber = serialNumber;
            MeterModelId = meterModelId;
            MeterNumber = meterNumber;
            FirmwareVersion = firmwareVersion;
            SwitchState = switchState;
        }

        public string SerialNumber { get; set; }
        public int MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public int SwitchState { get; set; }

        public string getMeterModelId()
        {
            return Enum.Parse(typeof(EMeterModel), this.MeterModelId.ToString()).ToString();
        }

        public string getSwitchState()
        {
            return Enum.Parse(typeof(ESwitchState), this.SwitchState.ToString()).ToString();
        }
    }
}
