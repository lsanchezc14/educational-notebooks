using ASCOM.Common.DeviceInterfaces;
using ASCOM.Alpaca.Discovery;
using ASCOM.Alpaca.Clients;
using ASCOM.Common;
using System.Drawing;
using OpenCvSharp;

namespace SeestarWhiska.DeviceAccess
{
    public class TelescopeV1 : ITelescopeV4
    {
        public AlpacaTelescope? AlpacaTelescope { get; set; }
        public AlpacaCamera? AlpacaCamera { get; set; }
        public List<AscomDevice>? AscomDeviceList;
        public bool TelescopeConnected = false;
        public string DeviceDescription = string.Empty;

        #region ITelescopeV4 Implementation
        public bool AtHome => AlpacaTelescope != null ? AlpacaTelescope.AtHome : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlew => AlpacaTelescope != null ? AlpacaTelescope.CanSlew : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlewAltAz => AlpacaTelescope != null ? AlpacaTelescope.CanSlewAltAz : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlewAltAzAsync => AlpacaTelescope != null ? AlpacaTelescope.CanSlewAltAzAsync : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSlewAsync => AlpacaTelescope != null ? AlpacaTelescope.CanSlewAsync : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public PointingState SideOfPier
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.SideOfPier : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
            set { if (AlpacaTelescope != null) AlpacaTelescope.SideOfPier = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public bool Tracking
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.Tracking : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
            set { if (AlpacaTelescope != null) AlpacaTelescope.Tracking = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public bool Connecting => AlpacaTelescope != null ? AlpacaTelescope.Connected : false;

        public List<StateValue> DeviceState => new List<StateValue>();

        public AlignmentMode AlignmentMode => AlpacaTelescope != null ? AlpacaTelescope.AlignmentMode : AlignmentMode.AltAz;

        public double Altitude => AlpacaTelescope != null ? AlpacaTelescope.Altitude : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public double ApertureArea => AlpacaTelescope != null ? AlpacaTelescope.ApertureArea : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public double ApertureDiameter => AlpacaTelescope != null ? AlpacaTelescope.ApertureDiameter : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool AtPark => AlpacaTelescope != null ? AlpacaTelescope.AtPark : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
        public double Azimuth => AlpacaTelescope != null ? AlpacaTelescope.Azimuth : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanFindHome => AlpacaTelescope != null ? AlpacaTelescope.CanFindHome : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanPark => AlpacaTelescope != null ? AlpacaTelescope.CanPark : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanPulseGuide => AlpacaTelescope != null ? AlpacaTelescope.CanPulseGuide : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSetDeclinationRate => AlpacaTelescope != null ? AlpacaTelescope.CanSetDeclinationRate : throw new InvalidOperationException("AlpacaTelescope is not initialized.");
        public bool CanSetGuideRates => AlpacaTelescope != null ? AlpacaTelescope.CanSetGuideRates : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSetPark => AlpacaTelescope != null ? AlpacaTelescope.CanSetPark : throw new InvalidOperationException("AlpacaTelescope is not initialized.");

        public bool CanSetPierSide => AlpacaTelescope != null ? AlpacaTelescope.CanSetPierSide : throw new InvalidOperationException("AlpacaTelescope is not initialized");
        public bool CanSetRightAscensionRate => AlpacaTelescope != null ? AlpacaTelescope.CanSetRightAscensionRate : false;

        public bool CanSetTracking => AlpacaTelescope != null ? AlpacaTelescope.CanSetTracking : false;

        public bool CanSync => AlpacaTelescope != null ? AlpacaTelescope.CanSync : false;

        public bool CanSyncAltAz => AlpacaTelescope != null ? AlpacaTelescope.CanSyncAltAz : false;

        public bool CanUnpark => AlpacaTelescope != null ? AlpacaTelescope.CanUnpark : false;

        public double Declination => AlpacaTelescope != null ? AlpacaTelescope.Declination : 0.0;

        public double DeclinationRate
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.DeclinationRate : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.DeclinationRate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public bool DoesRefraction
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.DoesRefraction : false;
            set { if (AlpacaTelescope != null) AlpacaTelescope.DoesRefraction = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public EquatorialCoordinateType EquatorialSystem => AlpacaTelescope != null ? AlpacaTelescope.EquatorialSystem : EquatorialCoordinateType.J2000;

        public double FocalLength => AlpacaTelescope != null ? AlpacaTelescope.FocalLength : 0.0;

        public double GuideRateDeclination
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.GuideRateDeclination : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.GuideRateDeclination = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double GuideRateRightAscension
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.GuideRateRightAscension : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.GuideRateRightAscension = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public bool IsPulseGuiding => AlpacaTelescope != null ? AlpacaTelescope.IsPulseGuiding : false;

        public double RightAscension => AlpacaTelescope != null ? AlpacaTelescope.RightAscension : 0.0;

        public double RightAscensionRate
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.RightAscensionRate : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.RightAscensionRate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public double SiderealTime => AlpacaTelescope != null ? AlpacaTelescope.SiderealTime : 0.0;

        public double SiteElevation
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.SiteElevation : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.SiteElevation = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double SiteLatitude
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.SiteLatitude : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.SiteLatitude = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double SiteLongitude
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.SiteLongitude : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.SiteLongitude = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public bool Slewing => AlpacaTelescope != null ? AlpacaTelescope.Slewing : false;

        public short SlewSettleTime
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.SlewSettleTime : (short)0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.SlewSettleTime = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double TargetDeclination
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.TargetDeclination : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.TargetDeclination = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public double TargetRightAscension
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.TargetRightAscension : 0.0;
            set { if (AlpacaTelescope != null) AlpacaTelescope.TargetRightAscension = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public DriveRate TrackingRate
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.TrackingRate : DriveRate.Lunar;
            set { if (AlpacaTelescope != null) AlpacaTelescope.TrackingRate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }

        public ITrackingRates TrackingRates => AlpacaTelescope != null ? AlpacaTelescope.TrackingRates : null;

        public DateTime UTCDate
        {
            get => AlpacaTelescope != null ? AlpacaTelescope.UTCDate : DateTime.MinValue;
            set { if (AlpacaTelescope != null) AlpacaTelescope.UTCDate = value; else throw new InvalidOperationException("AlpacaTelescope is not initialized."); }
        }
        public bool Connected { get; set; }

        public string Description => AlpacaTelescope != null ? AlpacaTelescope.Description : string.Empty;

        public string DriverInfo => AlpacaTelescope != null ? AlpacaTelescope.DriverInfo : string.Empty;

        public string DriverVersion => AlpacaTelescope != null ? AlpacaTelescope.DriverVersion : string.Empty;

        public short InterfaceVersion => AlpacaTelescope != null ? AlpacaTelescope.InterfaceVersion : (short)0;

        public string Name => AlpacaTelescope != null ? AlpacaTelescope.Name : string.Empty;

        public IList<string> SupportedActions => AlpacaTelescope != null ? AlpacaTelescope.SupportedActions : new List<string>();

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

        public PointingState DestinationSideOfPier(double RightAscension, double Declination)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            this.AlpacaTelescope.Connected = false;
            TelescopeConnected = false;
            this.Dispose();
        }

        public void Dispose()
        {
            this.AlpacaTelescope.Dispose();
        }

        public void FindHome()
        {
            this.AlpacaTelescope.FindHome();
        }

        public void MoveAxis(TelescopeAxis axis, double rate)
        {
            System.Console.WriteLine($"Axis {axis.ToString()} with rate: {rate.ToString()}");
            this.AlpacaTelescope.MoveAxis(axis, rate);
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

        #endregion

        #region Additional Methods

        public async Task DiscoverDevicesAsync()
        {
            AscomDeviceList = await AlpacaDiscovery.GetAscomDevicesAsync(DeviceTypes.Telescope);
            AscomDeviceList = AscomDeviceList.Where(d => !d.IpAddress.Equals("127.0.0.1")).ToList();
        }

        public async void ConnectAsync(AscomDevice telescope)
        {
            AlpacaTelescope = AlpacaClient.GetDevice<AlpacaTelescope>(telescope);
            if (AlpacaTelescope != null)
            {
                AlpacaTelescope.Connected = true;
                TelescopeConnected = AlpacaTelescope.Connected;
                DeviceDescription = AlpacaTelescope.Description;
            }
        }

        public void ConnectCamera(AscomDevice telescope)
        {
            AlpacaCamera = AlpacaClient.GetDevice<AlpacaCamera>(telescope);
            if (telescope != null)
            {
                AlpacaCamera.Connected = true;
            }
        }

        public object? GetCameraImageArrayAsync(bool isColorImage = true)
        {
            if (AlpacaCamera != null)
            {
                AlpacaCamera.Gain = 0;
                int width = 1920;
                int height = 1080;
                
                //AlpacaCamera.StartExposure(0.0001, false);
                AlpacaCamera.StartExposure(1, false);
                while (!AlpacaCamera.ImageReady) 
                { 
                    Thread.Sleep(100); 
                }

                object? imageObj = AlpacaCamera.ImageArray;
                int[,] image = imageObj as int[,];                   

                // if (image != null)
                // {
                //     using (var writer = new System.IO.StreamWriter("output.csv"))
                //     {
                //         for (int y = 0; y < height; y++)
                //         {
                //             string[] row = new string[width];
                //             for (int x = 0; x < width; x++)
                //             {
                //                 row[x] = image[y, x].ToString();
                //             }
                //             writer.WriteLine(string.Join(",", row));
                //         }
                //     }
                // }

                int min = int.MaxValue;
                int max = int.MinValue;

                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                    {
                        int v = image[y, x];
                        if (v < min) min = v;
                        if (v > max) max = v;
                    }
                double range = (max > min) ? (max - min) : 1.0;

                if (isColorImage)
                {
                    int rows = image.GetLength(0);
                    int cols = image.GetLength(1);

                    Mat rawImage = new Mat(rows, cols, MatType.CV_32SC1);
                    Mat rgbImage = new Mat();

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            rawImage.Set(i, j, image[i, j]);
                        }
                    }

                    Cv2.CvtColor(rawImage, rgbImage, ColorConversionCodes.BayerRG2BGR);
                    Cv2.ImWrite("photo_rgb.png", rgbImage);
                }

                // Create and save normalized bitmap
                using (Bitmap bmp = new Bitmap(width, height))
                {
                    for (int y = 0; y < height; y++)
                        for (int x = 0; x < width; x++)
                        {
                            int v = (int)Math.Round((image[y, x] - min) * 255.0 / range);
                            v = Math.Max(0, Math.Min(255, v));
                            bmp.SetPixel(x, y, Color.FromArgb(v, v, v));
                        }
                    bmp.Save($"photo.png", System.Drawing.Imaging.ImageFormat.Png);
                }

                return image;
            }

            return null;
        }
        #endregion
    }
}