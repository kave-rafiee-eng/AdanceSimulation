using ElavatorSimilator.Models;
using ElavatorSimilator.ViewModels;
using ElavatorSimulator.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElavatorSimilator.process
{
    public class JsonProcessor
    {
        private readonly SystemPanelViewModel _panelViewModel;
        private readonly CallsViewModel _callsViewModel;
        private readonly LocationViewModel _locationViewModel;
        private readonly ButtonsMainViewModel _buttonsMainViewModel;
        private readonly ChartViewModel _chartmotorferqViewModel;
        private readonly ChartPlotViewModel _ChartPlotViewModel;
        public JsonProcessor(SystemPanelViewModel panelVM, CallsViewModel callsVM, LocationViewModel locationVM, ButtonsMainViewModel ButtonsVM , ChartPlotViewModel chatfeqVM)
        {
            _panelViewModel = panelVM;
            _callsViewModel = callsVM;
            _locationViewModel = locationVM;
            _buttonsMainViewModel = ButtonsVM;
            _ChartPlotViewModel = chatfeqVM;
        }

        public void Process(string data)
        {
            
            if (TryParseJson(data, out JToken token) && token.Type == JTokenType.Object)
            {
                var obj = (JObject)token;
                var groupData = new List<SystemPanelData>();

                if (obj.TryGetValue("ENCfloor", out JToken ENCfloorToken) && ENCfloorToken is JArray dataArray)
                {
                    List<double> values = new List<double>();

                    foreach (JToken item in dataArray)
                    {
                        if (double.TryParse(item.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                        {
                            values.Add(value);

                        }
                    }

                    Application.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (_locationViewModel.ModeENCactive == true)
                        {
                            _locationViewModel.InitializeFloorMarkers(values);
                        }   
                        else
                        {
                            List<double> emptyValue = new List<double>();
                            _locationViewModel.InitializeFloorMarkers(emptyValue);
                        }
                    });
                }

                if (obj.TryGetValue("ENC1cfup", out JToken ENC1cfupToken) && ENC1cfupToken is JArray ENC1cfupArray)
                {
                    List<double> values = new List<double>();

                    foreach (JToken item in ENC1cfupArray)
                    {
                        if (double.TryParse(item.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                        {
                            values.Add(value);

                        }
                    }

                    Application.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (_locationViewModel.ModeENCactive == true)
                        {
                            _locationViewModel.Initialize_1CFUP(values);
                        }
                        else
                        {
                            List<double> emptyValue = new List<double>();
                            _locationViewModel.Initialize_1CFUP(emptyValue);
                        }
                    });
                }

                double Loc = 0;
                double Line1 = 0;
                double Line2 = 0;

                bool F_Loc = false;
                bool F_Line1 = false;
                bool F_Line2 = false;

                if (obj.TryGetValue("LocInMeter", out JToken LocInMeterToken))
                {
                    if (double.TryParse(LocInMeterToken.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double LocInMeterValue))
                    {
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            if (_locationViewModel.ModeENCactive == true)
                            {
                                _locationViewModel.LocInMeter = LocInMeterValue/1000;
                                _locationViewModel.Y = 400 - (50 / 3) * LocInMeterValue/1000;
                            }
                            else _locationViewModel.LocInMeter = 0;

                            _locationViewModel.LocationInMiles = LocInMeterValue;
                            Loc = LocInMeterValue;
                            F_Loc = true;

                        });
                    }
                }

                if (obj.TryGetValue("Ferq", out JToken ferqToken))
                {
                    if (double.TryParse(ferqToken.ToString(), out double ferqValue))
                    {
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            _locationViewModel.Ferq = ferqValue;
                        });
                        
                    }
                }

                if (obj.TryGetValue("Line1", out JToken Line1Token))
                {
                    if (double.TryParse(Line1Token.ToString(), out double Line1Value))
                    {
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                           _ChartPlotViewModel.AddDataPoint( 0 , 0, Line1Value , 0 );
                        });

                        Line1 = Line1Value;
                        F_Line1 = true;
                    }
                }

                if (obj.TryGetValue("Line2", out JToken Line2Token))
                {
                    if (double.TryParse(Line2Token.ToString(), out double Line2Value))
                    {
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            _ChartPlotViewModel.AddDataPoint( 0 , 1, Line2Value , 0);

                        });

                        Line2 = Line2Value;
                        F_Line2 = true;
                    }
                }

                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (F_Loc && F_Line1)
                    {
                        _ChartPlotViewModel.AddDataPoint(1, 0, Line1, Loc);
                    }

                    if (F_Loc && F_Line2)
                    {
                        _ChartPlotViewModel.AddDataPoint(1, 1, Line2, Loc);
                    }
                });

                if (obj.TryGetValue("Goal", out JToken goalToken) )
                {
                    if (double.TryParse(goalToken.ToString(), out double goalValue) )
                    {
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            if (_locationViewModel.ModeENCactive == false)
                            {
                                _locationViewModel.Goal = goalValue;
                                _locationViewModel.Y_Goal = 350 - (goalValue * 50);
                            }
                            else
                            {
                                _locationViewModel.Goal = 0;
                                _locationViewModel.Y_Goal = 0;
                            }

                        });

                    }
                }

                if (obj.TryGetValue("Pre", out JToken preGoalToken) )
                {
                    if (double.TryParse(preGoalToken.ToString(), out double preGoalValue) )
                    {
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            if (_locationViewModel.ModeENCactive == false)
                            {
                                _locationViewModel.PreGoal = preGoalValue;
                                _locationViewModel.Y_PreGoal = 350 - (preGoalValue * 50);
                            }
                            else
                            {
                                _locationViewModel.PreGoal = 0;
                                _locationViewModel.Y_PreGoal = 0;
                            }

                        });

                    }
                }

                if ( obj.TryGetValue("F", out JToken floorToken) && obj.TryGetValue("inF", out JToken infloorToken) )
                {
                    if ( double.TryParse(floorToken.ToString(), out double floorValue) &&
                        double.TryParse(infloorToken.ToString(), out double infloorValue)
                        )
                    {
                            
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            if (_locationViewModel.ModeENCactive == false)
                            {
                                _locationViewModel.Floor = floorValue;
                                _locationViewModel.InFloor = infloorValue;

                                _locationViewModel.Y = 387.5 - ((floorValue * 50) + (infloorValue - 1) * 12.5);
                            }
                            else
                            {
                                _locationViewModel.Floor = 0;
                                _locationViewModel.InFloor = 0;
                            }

                         });

                        
                    }
                }

                foreach (var property in obj.Properties())
                {
                    if (property.Value.Type == JTokenType.Array)
                    {
                        if (property.Name == "PB")
                        {
                            Debug.WriteLine("---------- Processing Button Commands");

                            var buttonArray = (JArray)property.Value;

                            var directionMapping = new Dictionary<int, int>
                            {
                                { 0, 1 }, // uni -> 1
                                { 1, 1 }, // vip -> 1
                                { 2, 0 }, // up  -> 0
                                { 3, 2 }  // down -> 2
                            };


                            Application.Current.Dispatcher.BeginInvoke(() =>
                            {
                                for (int floor = 0; floor < 10; floor++)
                                {
                                    for( int door = 0; door < 3; door++)
                                    {
                                        _buttonsMainViewModel.UpdateButtonColor(1, floor, door, 3, Brushes.Transparent);
                                        for (int dir = 0; dir < 3; dir++)
                                        {
                                            _buttonsMainViewModel.UpdateButtonColor( 0 , floor, door, dir, Brushes.Transparent);
                                        }
                                    }
                                }
                            });
                            
                            foreach (JObject joButton in buttonArray)
                            {
                                int from = (int)joButton["from"];
                                int floor = (int)joButton["floor"];
                                int dirRaw = (int)joButton["dir"];
                                int door1 = (int)joButton["door1"];
                                int door2 = (int)joButton["door2"];
                                int door3 = (int)joButton["door3"];

                                int set = (int)joButton["set"];
                                int led = (int)joButton["led"];

                                if (!directionMapping.TryGetValue(dirRaw, out int dirMapped))
                                {
                                    Debug.WriteLine($"Invalid direction code: {dirRaw}");
                                    continue;
                                }

                                Debug.WriteLine($"From: {from}, Floor: {floor}, DirMapped: {dirMapped}");

                                Application.Current.Dispatcher.BeginInvoke(() =>
                                {
                                    Brush color = Brushes.Red;
                                    if (led == 1) color = Brushes.Gold;
                                    if ( set == 1 && led == 1 ) color = Brushes.Blue;


                                    if ( from == 0)
                                    {
                                        if (door1 == 1) _buttonsMainViewModel.UpdateButtonColor(from, floor, 0, dirMapped, color);
                                        if (door2 == 1) _buttonsMainViewModel.UpdateButtonColor(from, floor, 1, dirMapped, color);
                                        if (door3 == 1) _buttonsMainViewModel.UpdateButtonColor(from, floor, 2, dirMapped, color);
                                    }
                                    else
                                    {
                                        if (door1 == 1) _buttonsMainViewModel.UpdateButtonColor(from, floor, 0, 3, color );
                                        if (door2 == 1) _buttonsMainViewModel.UpdateButtonColor(from, floor, 1, 3, color );
                                        if (door3 == 1) _buttonsMainViewModel.UpdateButtonColor(from, floor, 2, 3, color );
                                    }
                                });
                            }
                        }

                        //------------------------------------------------

                        if (property.Name == "calls")
                        {
                            Debug.WriteLine("---------- Calls");
                            var calls = property.Value.ToObject<List<Call>>();

                            Application.Current.Dispatcher.BeginInvoke(() =>
                            {
                                _callsViewModel.ClearCalls();
                                foreach (var call in calls)
                                {
                                    _callsViewModel.AddCall(call);
                                }
                            });

                        }

                    }
                    else if (property.Value.Type == JTokenType.Object)
                    {
                        var panel = new SystemPanelData
                        {
                            Title = property.Name
                        };

                        foreach (var subField in ((JObject)property.Value).Properties())
                        {
                            panel.Items.Add(new SystemItem
                            {
                                Label = subField.Name,
                                Value = subField.Value.ToString()
                            });
                        }

                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            _panelViewModel.ClearPanels();
                            foreach (var panel in groupData)
                            {
                                _panelViewModel.AddPanel(panel);
                            }
                        });

                        groupData.Add(panel);
                    }
                }

            }
        }

        private bool TryParseJson(string data, out JToken token)
        {
            try
            {
                token = JToken.Parse(data);
                return true;
            }
            catch
            {
                token = null;
                return false;
            }
        }
    }
}
