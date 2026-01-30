using ASCOM.Common.DeviceInterfaces;
using ASCOM.Alpaca.Discovery;
using ASCOM.Alpaca.Clients;
using ASCOM.Common;

namespace SeestarWhiska.DeviceAccess
{
    public class TelescopeV1 : ITelescopeV4
    {
        public AlpacaTelescope? alpacaTelescope { get; set; }
        public List<AscomDevice>? ascomDeviceList;
        public bool telescopeConnected = false;

        // public string deviceName = string.Empty;
        // public string deviceDriverInfo = string.Empty;
        // public string deviceSupportedActions = string.Empty;
        // public string deviceDriverVersion = string.Empty;
        
        public string deviceDescription = string.Empty;
        public bool AtHome => alpacaTelescope != null ? alpacaTelescope.AtHome : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlew => alpacaTelescope != null ? alpacaTelescope.CanSlew : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlewAltAz => alpacaTelescope != null ? alpacaTelescope.CanSlewAltAz : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlewAltAzAsync => alpacaTelescope != null ? alpacaTelescope.CanSlewAltAzAsync : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlewAsync => alpacaTelescope != null ? alpacaTelescope.CanSlewAsync : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public PointingState SideOfPier
        {
            get => alpacaTelescope != null ? alpacaTelescope.SideOfPier : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
            set { if (alpacaTelescope != null) alpacaTelescope.SideOfPier = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public bool Tracking
        {
            get => alpacaTelescope != null ? alpacaTelescope.Tracking : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
            set { if (alpacaTelescope != null) alpacaTelescope.Tracking = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public bool Connecting => alpacaTelescope != null ? alpacaTelescope.Connected : false;

        public List<StateValue> DeviceState => new List<StateValue>();

        public AlignmentMode AlignmentMode => alpacaTelescope != null ? alpacaTelescope.AlignmentMode : AlignmentMode.AltAz;

        public double Altitude => alpacaTelescope != null ? alpacaTelescope.Altitude : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public double ApertureArea => alpacaTelescope != null ? alpacaTelescope.ApertureArea : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public double ApertureDiameter => alpacaTelescope != null ? alpacaTelescope.ApertureDiameter : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool AtPark => alpacaTelescope != null ? alpacaTelescope.AtPark : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
        public double Azimuth => alpacaTelescope != null ? alpacaTelescope.Azimuth : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanFindHome => alpacaTelescope != null ? alpacaTelescope.CanFindHome : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanPark => alpacaTelescope != null ? alpacaTelescope.CanPark : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanPulseGuide => alpacaTelescope != null ? alpacaTelescope.CanPulseGuide : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSetDeclinationRate => alpacaTelescope != null ? alpacaTelescope.CanSetDeclinationRate : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
        public bool CanSetGuideRates => alpacaTelescope != null ? alpacaTelescope.CanSetGuideRates : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSetPark => alpacaTelescope != null ? alpacaTelescope.CanSetPark : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSetPierSide => alpacaTelescope != null ? alpacaTelescope.CanSetPierSide : throw new InvalidOperationException("AlpacaTelescope is not initialized");
        public bool CanSetRightAscensionRate => alpacaTelescope != null ? alpacaTelescope.CanSetRightAscensionRate : false;

        public bool CanSetTracking => alpacaTelescope != null ? alpacaTelescope.CanSetTracking : false;

        public bool CanSync => alpacaTelescope != null ? alpacaTelescope.CanSync : false;

        public bool CanSyncAltAz => alpacaTelescope != null ? alpacaTelescope.CanSyncAltAz : false;

        public bool CanUnpark => alpacaTelescope != null ? alpacaTelescope.CanUnpark : false;

        public double Declination => alpacaTelescope != null ? alpacaTelescope.Declination : 0.0;

        public double DeclinationRate
        {
            get => alpacaTelescope != null ? alpacaTelescope.DeclinationRate : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.DeclinationRate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public bool DoesRefraction
        {
            get => alpacaTelescope != null ? alpacaTelescope.DoesRefraction : false;
            set { if (alpacaTelescope != null) alpacaTelescope.DoesRefraction = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public EquatorialCoordinateType EquatorialSystem => alpacaTelescope != null ? alpacaTelescope.EquatorialSystem : EquatorialCoordinateType.J2000;

        public double FocalLength => alpacaTelescope != null ? alpacaTelescope.FocalLength : 0.0;

        public double GuideRateDeclination
        {
            get => alpacaTelescope != null ? alpacaTelescope.GuideRateDeclination : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.GuideRateDeclination = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double GuideRateRightAscension
        {
            get => alpacaTelescope != null ? alpacaTelescope.GuideRateRightAscension : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.GuideRateRightAscension = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public bool IsPulseGuiding => alpacaTelescope != null ? alpacaTelescope.IsPulseGuiding : false;

        public double RightAscension => alpacaTelescope != null ? alpacaTelescope.RightAscension : 0.0;

        public double RightAscensionRate
        {
            get => alpacaTelescope != null ? alpacaTelescope.RightAscensionRate : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.RightAscensionRate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public double SiderealTime => alpacaTelescope != null ? alpacaTelescope.SiderealTime : 0.0;

        public double SiteElevation
        {
            get => alpacaTelescope != null ? alpacaTelescope.SiteElevation : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.SiteElevation = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double SiteLatitude
        {
            get => alpacaTelescope != null ? alpacaTelescope.SiteLatitude : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.SiteLatitude = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double SiteLongitude
        {
            get => alpacaTelescope != null ? alpacaTelescope.SiteLongitude : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.SiteLongitude = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public bool Slewing => alpacaTelescope != null ? alpacaTelescope.Slewing : false;

        public short SlewSettleTime
        {
            get => alpacaTelescope != null ? alpacaTelescope.SlewSettleTime : (short)0;
            set { if (alpacaTelescope != null) alpacaTelescope.SlewSettleTime = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double TargetDeclination
        {
            get => alpacaTelescope != null ? alpacaTelescope.TargetDeclination : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.TargetDeclination = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double TargetRightAscension
        {
            get => alpacaTelescope != null ? alpacaTelescope.TargetRightAscension : 0.0;
            set { if (alpacaTelescope != null) alpacaTelescope.TargetRightAscension = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public DriveRate TrackingRate
        {
            get => alpacaTelescope != null ? alpacaTelescope.TrackingRate : DriveRate.Lunar;
            set { if (alpacaTelescope != null) alpacaTelescope.TrackingRate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public ITrackingRates TrackingRates => alpacaTelescope != null ? alpacaTelescope.TrackingRates : null;

        public DateTime UTCDate
        {
            get => alpacaTelescope != null ? alpacaTelescope.UTCDate : DateTime.MinValue;
            set { if (alpacaTelescope != null) alpacaTelescope.UTCDate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public bool Connected { get; set; }

        public string Description => alpacaTelescope != null ? alpacaTelescope.Description : string.Empty;

        public string DriverInfo => alpacaTelescope != null ? alpacaTelescope.DriverInfo : string.Empty;

        public string DriverVersion => alpacaTelescope != null ? alpacaTelescope.DriverVersion : string.Empty;

        public short InterfaceVersion => alpacaTelescope != null ? alpacaTelescope.InterfaceVersion : (short)0;

        public string Name => alpacaTelescope != null ? alpacaTelescope.Name : string.Empty;

        public IList<string> SupportedActions => alpacaTelescope != null ? alpacaTelescope.SupportedActions : new List<string>();

        public void AbortSlew()
        {
            throw new NotImplementedException();
        }

        public string Action(string actionName, string actionParameters)
        {
            throw new NotImplementedException();
        }

        public IAxisRates AxisRates(TelescopeAxis Axis)
        {
            throw new NotImplementedException();
        }

        public bool CanMoveAxis(TelescopeAxis Axis)
        {
            throw new NotImplementedException();
        }

        public void CommandBlind(string command, bool raw = false)
        {
            throw new NotImplementedException();
        }

        public bool CommandBool(string command, bool raw = false)
        {
            throw new NotImplementedException();
        }

        public string CommandString(string command, bool raw = false)
        {
            throw new NotImplementedException();
        }

        public async Task DiscoverDevicesAsync()
        {
            ascomDeviceList = await AlpacaDiscovery.GetAscomDevicesAsync(DeviceTypes.Telescope);
        }

        public async void ConnectAsync(AscomDevice telescope)
        {

            // This returns a list of ConfiguredDevice objects with device info
            // foreach (var device in devices)
            // {
            //     Console.WriteLine($"Device: {device.HostName}, Type: {device.IpAddress}");
            // }

            // var telescope = ascomDeviceList.FirstOrDefault(d => d.IpAddress.Equals("192.168.1.38"));

            alpacaTelescope = AlpacaClient.GetDevice<AlpacaTelescope>(telescope);
            if (alpacaTelescope != null)
            {
                // Get the device's description
                alpacaTelescope.Connected = true;
                telescopeConnected = alpacaTelescope.Connected;
                deviceDescription = alpacaTelescope.Description;


                // Disconnect form the Alpaca device
                //alpacaTelescope.Connected = false;
            }
        }

        public PointingState DestinationSideOfPier(double RightAscension, double Declination)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            this.alpacaTelescope.Connected = false;
            telescopeConnected = false;
            this.Dispose();
        }

        public void Dispose()
        {
            this.alpacaTelescope.Dispose();
        }

        public void FindHome()
        {
            this.alpacaTelescope.FindHome();
        }

        public void MoveAxis(TelescopeAxis Axis, double Rate)
        {
            throw new NotImplementedException();
        }

        public void Park()
        {
            throw new NotImplementedException();
        }

        public void PulseGuide(GuideDirection Direction, int Duration)
        {
            throw new NotImplementedException();
        }

        public void SetPark()
        {
            throw new NotImplementedException();
        }

        public void SlewToAltAz(double Azimuth, double Altitude)
        {
            throw new NotImplementedException();
        }

        public void SlewToAltAzAsync(double Azimuth, double Altitude)
        {
            throw new NotImplementedException();
        }

        public void SlewToCoordinates(double RightAscension, double Declination)
        {
            throw new NotImplementedException();
        }

        public void SlewToCoordinatesAsync(double RightAscension, double Declination)
        {
            throw new NotImplementedException();
        }

        public void SlewToTarget()
        {
            throw new NotImplementedException();
        }

        public void SlewToTargetAsync()
        {
            throw new NotImplementedException();
        }

        public void SyncToAltAz(double Azimuth, double Altitude)
        {
            throw new NotImplementedException();
        }

        public void SyncToCoordinates(double RightAscension, double Declination)
        {
            throw new NotImplementedException();
        }

        public void SyncToTarget()
        {
            throw new NotImplementedException();
        }

        public void Unpark()
        {
            throw new NotImplementedException();
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }
    }
}