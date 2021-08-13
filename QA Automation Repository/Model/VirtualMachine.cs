using System;
using TestProject.Enums;

namespace TestProject.Model
{
    public class VirtualMachine
    {
        private uint _numberOfInstances;
        public uint NumberOfInstances
        {
            get
            {
                return _numberOfInstances;
            }
            set
            {
                _numberOfInstances = value;
            }
        }

        private VMSeries _vMSerial;

        public VMSeries VMSerial
        {
            get
            {
                return _vMSerial;
            }
            set
            {
                _vMSerial = value;
            }
        }

        public string VMType { get; set; }

        public string VMVolume { get; set; }

        private uint _numberOfGPUs;

        public uint NumberOfGPUs
        {
            get
            {
                return _numberOfGPUs;
            }
            set
            {
                _numberOfGPUs = value;
            }
        }

        private GPUTypes _gPUType;

        public GPUTypes GPUType
        {
            get
            {
                return _gPUType;
            }
            set
            {
                _gPUType = value;
            }
        }

        public string Region { get; set; }

        private uint _commitedUsage;

        public uint CommitedUsage
        {
            get
            {
                return _commitedUsage;
            }
            set
            {
                _commitedUsage = value;
            }
        }

        public VirtualMachine(string numberOfInstances, string vMSerial, string vMType, string vMVolume, string numberOfGPUs, string gPUType, string region, string commitedUsage)
        {
            UInt32.TryParse(numberOfInstances, out _numberOfInstances);
            Enum.TryParse(vMSerial, out _vMSerial);
            VMType = vMType;
            VMVolume = vMVolume;
            UInt32.TryParse(numberOfGPUs, out _numberOfGPUs);
            Enum.TryParse(gPUType, out _gPUType);
            Region = region;
            UInt32.TryParse(commitedUsage, out _commitedUsage);
        }

    }
}
