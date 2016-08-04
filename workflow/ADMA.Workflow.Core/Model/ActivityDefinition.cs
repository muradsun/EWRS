﻿using System.Collections.Generic;

namespace ADMA.Workflow.Core.Model
{
    public class ActivityDefinition : BaseDefinition
    {
        public string State { get; internal set; }
        public bool IsInitial { get; internal set; }
        public bool IsFinal { get; internal set; }
        public bool IsForSetState { get; internal set; }
        public bool IsAutoSchemeUpdate { get; internal set; }

        public bool HaveImplementation
        {
            get { return Implementation.Count > 0; }
        }

        public bool HavePreExecutionImplementation
        {
            get { return PreExecutionImplementation.Count > 0; }
        }

        public List<ActionDefinitionForActivity> Implementation { get; internal set; }

        public List<ActionDefinitionForActivity> PreExecutionImplementation { get; internal set; } 

        public bool IsState
        {
            get { return !string.IsNullOrEmpty(Name); }
        }

        public static ActivityDefinition Create(string name, string stateName, string isInitial, string isFinal, string isForSetState, string isAutoSchemeUpdate)
        {
            return new ActivityDefinition()
                       {
                           IsFinal = !string.IsNullOrEmpty(isFinal) && bool.Parse(isFinal),
                           IsInitial = !string.IsNullOrEmpty(isInitial) && bool.Parse(isInitial),
                           IsForSetState = !string.IsNullOrEmpty(isForSetState) && bool.Parse(isForSetState),
                           IsAutoSchemeUpdate = !string.IsNullOrEmpty(isAutoSchemeUpdate) && bool.Parse(isAutoSchemeUpdate),
                           Name = name,
                           State = stateName,
                           Implementation = new List<ActionDefinitionForActivity>(),
                           PreExecutionImplementation = new List<ActionDefinitionForActivity>()
                       };
        }

        public void AddAction(ActionDefinitionForActivity action)
        {
            Implementation.Add(action);
        }

        public void AddPreExecutionAction(ActionDefinitionForActivity action)
        {
            PreExecutionImplementation.Add(action);
        }
    }
}
