using ElavatorSimilator.Models;
using ElavatorSimilator.ViewModels;
using ElavatorSimulator.ViewModels;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElavatorSimilator.process
{
    public class JsonProcessor
    {
        private readonly SystemPanelViewModel _panelViewModel;
        private readonly CallsViewModel _callsViewModel;
        private readonly LocationViewModel _locationViewModel;
        public JsonProcessor(SystemPanelViewModel panelVM, CallsViewModel callsVM, LocationViewModel locationVM )
        {
            _panelViewModel = panelVM;
            _callsViewModel = callsVM;
            _locationViewModel = locationVM;
        }

        public void Process(string data)
        {
            
            if (TryParseJson(data, out JToken token) && token.Type == JTokenType.Object)
            {
                var obj = (JObject)token;
                var groupData = new List<SystemPanelData>();

                if (obj.TryGetValue("Goal", out JToken goalToken) )
                {
                    if (double.TryParse(goalToken.ToString(), out double goalValue) )
                    {
                        _locationViewModel.Goal = goalValue;
                        _locationViewModel.Y_Goal = 350 - ( goalValue * 50 );
                    }
                }

                if (obj.TryGetValue("Pre", out JToken preGoalToken) )
                {
                    if (double.TryParse(preGoalToken.ToString(), out double preGoalValue) )
                    {
                        _locationViewModel.PreGoal = preGoalValue;
                        _locationViewModel.Y_PreGoal = 350 - ( preGoalValue * 50 );
                    }
                }

                if ( obj.TryGetValue("F", out JToken floorToken) && obj.TryGetValue("inF", out JToken infloorToken) )
                {
                    if ( double.TryParse(floorToken.ToString(), out double floorValue) &&
                        double.TryParse(infloorToken.ToString(), out double infloorValue)
                        )
                    {
                        _locationViewModel.Floor = floorValue;
                        _locationViewModel.InFloor = infloorValue;

                        _locationViewModel.Y = 387.5 - ( ( floorValue*50 ) + (infloorValue-1)*12.5 );
                    }
                }

                foreach (var property in obj.Properties())
                {
                    if (property.Value.Type == JTokenType.Array)
                    {
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
