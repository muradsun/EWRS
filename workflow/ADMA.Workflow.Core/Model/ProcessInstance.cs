using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ADMA.Workflow.Core.Model
{
    public class ProcessInstance
    {
        public Guid ProcessId { get; internal set; }
        public Guid SchemeId { get; internal set; }
        public ProcessDefinition ProcessScheme { get; set; }
        public bool IsSchemeObsolete { get; internal set; }
        public bool IsDeterminingParametersChanged { get; internal set; }

        public IEnumerable<ParameterDefinitionWithValue> ProcessParameters
        {
            get { return _processParameters; }
        }

        private readonly List<ParameterDefinitionWithValue> _processParameters = new List<ParameterDefinitionWithValue>();


        public static ProcessInstance Create(Guid schemeId, Guid processId, ProcessDefinition processScheme, bool isSchemeObsolete, bool isDeterminingParametersChanged)
        {
            return new ProcessInstance() {SchemeId = schemeId, ProcessId = processId, ProcessScheme = processScheme, IsSchemeObsolete = isSchemeObsolete, IsDeterminingParametersChanged = isDeterminingParametersChanged};
        }

        public void AddParameter (ParameterDefinitionWithValue parameter)
        {
            _processParameters.RemoveAll(p => p.Name == parameter.Name);
            _processParameters.Add(parameter);
        }

        public void AddParameters(IEnumerable<ParameterDefinitionWithValue> parameters)
        {
            _processParameters.RemoveAll(ep => parameters.Count(p=>p.Name == ep.Name) > 0);
            _processParameters.AddRange(parameters);
        }

        public ParameterDefinitionWithValue GetParameter(string name)
        {
            return _processParameters.SingleOrDefault(p => p.Name == name);
        }

        
        public string CurrentActivityName
        {
            get
            {
                var parameter = GetParameter(DefaultDefinitions.ParameterCurrentActivity.Name);
                return parameter == null ? null : (string) parameter.Value;
            }
        }

        public ActivityDefinition CurrentActivity
        {
            get { return ProcessScheme.FindActivity(CurrentActivityName); }
        }

        public void SetProcessParameters(List<ParameterDefinitionWithValue> pd)
        {
            _processParameters.Clear();
            AddParameters(pd);
        }

        #region Localized
        public string GetLocalizedStateName (string stateName, CultureInfo culture)
        {
            return ProcessScheme.GetLocalizedStateName(stateName, culture);
        }

        public string GetLocalizedCommandName(string commandName, CultureInfo culture)
        {
            return ProcessScheme.GetLocalizedCommandName(commandName, culture);
        }
        #endregion

        #region Debug info

        public string ProcessParametersToString(ParameterPurpose purpose)
        {
            StringBuilder res = new StringBuilder();
            foreach (var item in ProcessParameters.Where(p=>p.Purpose == purpose).OrderBy(p=>p.Name))
            {
                res.AppendLine(string.Format("{0}='{1}'", item.Name, item.Value));
            }
            return res.ToString();
        }
        #endregion
    }
}
