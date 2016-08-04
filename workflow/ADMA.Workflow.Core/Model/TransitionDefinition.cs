﻿using System;
using System.Collections.Generic;

namespace ADMA.Workflow.Core.Model
{
    public class TransitionDefinition : BaseDefinition
    {
        public ActivityDefinition From { get; set; }
        public ActivityDefinition To { get; set; }
        public TransitionClassifier Classifier { get; set; }
        public TriggerDefinition Trigger { get; set; }
        public ConditionDefinition Condition { get; set; }
       

        public IEnumerable<RestrictionDefinition> Restrictions
        {
            get { return RestrictionsList; }
        }


        protected List<RestrictionDefinition> RestrictionsList;
        
        public IEnumerable<OnErrorDefinition> OnErrors
        {
            get { return OnErrorsList; }
        }

        protected List<OnErrorDefinition> OnErrorsList;

        public static TransitionDefinition Create(string name, string clasifier, ActivityDefinition from, ActivityDefinition to, TriggerDefinition trigger, ConditionDefinition condition)
        {
            TransitionClassifier parsedClassifier;
            Enum.TryParse(clasifier, true, out parsedClassifier);
            return new TransitionDefinition()
                       {
                           Name = name,
                           To = to,
                           From = from,
                           Classifier = parsedClassifier,
                           Condition = condition ?? ConditionDefinition.Always,
                           Trigger = trigger ?? TriggerDefinition.Auto,
                           RestrictionsList = new List<RestrictionDefinition>(),
                           OnErrorsList = new List<OnErrorDefinition>()
                       };
        }

        public static TransitionDefinition Create(ActivityDefinition from, ActivityDefinition to)
        {
            return new TransitionDefinition()
            {
                Name = "Undefined",
                To = to,
                From = from,
                Classifier = TransitionClassifier.NotSpecified,
                Condition = ConditionDefinition.Always,
                Trigger = TriggerDefinition.Auto,
                RestrictionsList = new List<RestrictionDefinition>(),
                OnErrorsList = new List<OnErrorDefinition>()
            };
        }

        public void AddRestriction (RestrictionDefinition restriction)
        {
            RestrictionsList.Add(restriction);
        }

        public void AddOnError(OnErrorDefinition onError)
        {
            OnErrorsList.Add(onError);
        }
    }
}
